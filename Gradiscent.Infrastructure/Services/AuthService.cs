using Gradiscent.Application.Common;
using Gradiscent.Application.Dtos;
using Gradiscent.Application.Interfaces;
using Gradiscent.Domain.Enums;
using Gradiscent.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Gradiscent.API.Services
{
    public class AuthService:IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IEmailService emailService, IRefreshTokenRepository refreshTokenRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
            _configuration = configuration;
            _emailService = emailService;
            _refreshTokenRepository = refreshTokenRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<string>> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null) 
            {
                return ApiResponse<string>.FailedResponse("Email is already in use");
            }

            var newUser = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                Name = dto.FullName,
                UpdatedAt = DateTime.UtcNow,
                Status = UserStatus.PENDING_VERIFICATION
            };

            var result = await _userManager.CreateAsync(newUser, dto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return ApiResponse<string>.FailedResponse(errors);
            }
            if (!await _roleManager.RoleExistsAsync(dto.Role))
            {
                return ApiResponse<string>.FailedResponse($"Role '{dto.Role}' does not exist.");
            }

            await _userManager.AddToRoleAsync(newUser, dto.Role);
            var roles = await _userManager.GetRolesAsync(newUser);

            var jwtToken = _tokenService.CreateToken(newUser,roles);
            Console.WriteLine($"Generated token: {jwtToken}");
            Console.WriteLine($"Token length: {jwtToken.Length}");
            Console.WriteLine($"Token has dots: {jwtToken.Contains('.')}");
            Console.WriteLine($"Dot count: {jwtToken.Count(c => c == '.')}");

            var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmationToken));

            var confirmationLink = $"{_configuration["AppUrl"]}/api/v1/auth/verify?userId={newUser.Id}&token={encodedToken}";

            await _emailService.SendEmailAsync(
                newUser.Email,
                "Verify Your Gradiscent Account",
                $@"
                    <p>Hi <strong>{newUser.Name}</strong>,</p>
                    <p>Welcome to <b>Gradiscent</b> We're excited to have you onboard!</p>
                    <p>To complete your registration, please verify your email address by clicking the link below:</p>
                    <p>
                        <a href=""{confirmationLink}"" 
                           style=""display:inline-block; padding:10px 20px; 
                                  background-color:#4CAF50; color:#fff; 
                                  text-decoration:none; border-radius:5px;"">
                           Verify Email
                        </a>
                    </p>
                    <p>If you did not create an account, you can safely ignore this email.</p>
                    <br/>
                    <p>Best regards,<br/>The Gradiscent Team</p>

            ");

            return ApiResponse<string>.SuccessfulRespone(jwtToken, "Registered successfully! Please check your email for verification link.");
        }

        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return ApiResponse<LoginResponseDto>.FailedResponse("Invalid email or password");
            }
            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                return ApiResponse<LoginResponseDto>.FailedResponse("Please verify your email before logging in.");
            }

            if (user.Status != UserStatus.ACTIVE)
            {
                return ApiResponse<LoginResponseDto>.FailedResponse("Account is not active. Please contact support.");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded)
            {
                return ApiResponse<LoginResponseDto>.FailedResponse("Invalid email or password");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenService.CreateToken(user, roles);

            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.UtcNow.AddDays(7),
                CreatedAt = DateTime.UtcNow,
                CreatedByIp = _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "N/A",
                UserId = user.Id
            };

            await _refreshTokenRepository.AddAsync(refreshToken);

            var response = new LoginResponseDto
            {
                JwtToken = token,
                RefreshToken = refreshToken.Token
            };

            return ApiResponse<LoginResponseDto>.SuccessfulRespone(response, "Login successful");
        }

        public async Task<ApiResponse<LoginResponseDto>> RefreshTokenAsync(string token, string ipAddress)
        {
            var refreshToken = await _refreshTokenRepository.GetByTokenAsync(token);
            if(refreshToken == null)
            {
                return ApiResponse<LoginResponseDto>.FailedResponse("Invalid refresh token");
            }
            if (refreshToken.IsExpired)
            {
                return ApiResponse<LoginResponseDto>.FailedResponse("Refresh token has expired");
            }
            if (refreshToken.Revoked != null)
            {
                return ApiResponse<LoginResponseDto>.FailedResponse("Refresh token has been revoked");
            }

            var user = refreshToken.User;
            if (user == null)
            {
                return ApiResponse<LoginResponseDto>.FailedResponse("Invalid refresh token");
            }

            var roles = await _userManager.GetRolesAsync(user);

            var newJwtToken = _tokenService.CreateToken(user, roles);

            var newRefreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString("FXtSdIheFr8sLBhFCnDkZkBAKJkN8Z0-v2E9cleeW2U="),
                Expires = DateTime.UtcNow.AddDays(7),
                CreatedAt = DateTime.UtcNow,
                CreatedByIp = ipAddress,
                UserId = user.Id
            };
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken = newRefreshToken.Token;

            await _refreshTokenRepository.AddAsync(newRefreshToken);
            await _refreshTokenRepository.UpdateAsync(refreshToken);

            var response = new LoginResponseDto
            {
                JwtToken = newJwtToken,
                RefreshToken = newRefreshToken.Token
            };

            return ApiResponse<LoginResponseDto>.SuccessfulRespone(response, "Token refreshed successfully");
        }

        public async Task<ApiResponse<string>> VerifyEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return ApiResponse<string>.FailedResponse("Invalid user.");

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (!result.Succeeded)
                return ApiResponse<string>.FailedResponse("Email verification failed.");

            // mark as Active
            user.Status = UserStatus.ACTIVE;
            user.EmailConfirmed = true;
            user.UpdatedAt = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            await _emailService.SendEmailAsync(
                user.Email,
                "Welcome to Gradiscent 🎉",
                $@"
                    <p>Hi <strong>{user.Name}</strong>,</p>
        
                    <p>Congratulations! Your email has been successfully verified and your <b>Gradiscent</b> account is now active.</p>
        
                    <p>We’re excited to have you with us. With Gradiscent, you’ll have the tools and support you need to achieve your goals and make the most of your learning journey.</p>
        
                    <p>If you have any questions, our team is always here to help.</p>
        
                    <br/>
                    <p>Welcome aboard,<br/><strong>The Gradiscent Team</strong></p>
            ");
            return ApiResponse<string>.SuccessfulRespone("Email verified successfully. You can now log in.");
        }

        public async Task LogoutAsync(string refreshToken) 
        {
            var token = await _refreshTokenRepository.GetByTokenAsync(refreshToken);
            if (token != null) 
            {
                await _refreshTokenRepository.RomoveAsync(token);
            }
        }
    }
}
