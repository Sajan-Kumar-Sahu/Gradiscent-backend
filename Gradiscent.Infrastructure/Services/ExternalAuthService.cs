using Gradiscent.Application.Common;
using Gradiscent.Application.Dtos;
using Gradiscent.Application.Interfaces;
using Gradiscent.Domain.Enums;
using Gradiscent.Domain.Models;
using Gradiscent.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Gradiscent.Infrastructure.Services
{
    public class ExternalAuthService : IExternalAuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor? _httpContextAccessor;
        private readonly IEmailService _emailService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ExternalAuthService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ITokenService tokenService, IHttpContextAccessor? httpContextAccessor, IEmailService emailService, IRefreshTokenRepository refreshTokenRepository, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
            _refreshTokenRepository = refreshTokenRepository;
            _roleManager = roleManager;
        }

        public async Task<ApiResponse<LoginResponseDto>> LoginWithGoogleAsync(string requestedRole)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return ApiResponse<LoginResponseDto>.FailedResponse("Error loading external login information.");
            }

            var result = await _signInManager.ExternalLoginSignInAsync(
                info.LoginProvider,
                info.ProviderKey,
                isPersistent: false);

            ApplicationUser user;

            if (!result.Succeeded)
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var name = info.Principal.FindFirstValue(ClaimTypes.Name);
                if (email == null)
                {
                    return ApiResponse<LoginResponseDto>.FailedResponse("Email not provided by Google.");
                }
                var existingUser = await _userManager.FindByEmailAsync(email);
                if (existingUser != null)
                {
                    var loginResult = await _userManager.AddLoginAsync(existingUser, info);
                    if (!loginResult.Succeeded && loginResult.Errors.Any(e => e.Code != "LoginAlreadyAssociated"))
                    {
                        return ApiResponse<LoginResponseDto>.FailedResponse("Failed to link Google login.");
                    }
                    if (!await _userManager.IsInRoleAsync(existingUser, requestedRole))
                    {
                        if (!await _roleManager.RoleExistsAsync(requestedRole))
                        {
                            return ApiResponse<LoginResponseDto>.FailedResponse($"Role '{requestedRole}' does not exist.");
                        }
                        await _userManager.AddToRoleAsync(existingUser, requestedRole);
                    }
                    await _signInManager.SignInAsync(existingUser, isPersistent: false);
                    user = existingUser;
                }
                else
                {

                    user = new ApplicationUser 
                    { 
                        Name = name, 
                        UserName = email, 
                        Email = email, 
                        Status = UserStatus.ACTIVE, 
                        EmailConfirmed = true,
                        UpdatedAt = DateTime.UtcNow,
                    };

                    var createResult = await _userManager.CreateAsync(user);
                    if (!createResult.Succeeded)
                    {
                        var errors = string.Join(", ", createResult.Errors.Select(e => e.Description));
                        return ApiResponse<LoginResponseDto>.FailedResponse(errors);
                    }

                    if (!await _roleManager.RoleExistsAsync(requestedRole))
                    {
                        return ApiResponse<LoginResponseDto>.FailedResponse($"Role '{requestedRole}' does not exist.");
                    }

                    await _userManager.AddToRoleAsync(user, requestedRole);

                    await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false);
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
                }
            }
            else
            {
                user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            }

            var roles = await _userManager.GetRolesAsync(user);
            var jwtToken = _tokenService.CreateToken(user, roles);
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
                JwtToken = jwtToken,
                RefreshToken = refreshToken.Token
            };
            return ApiResponse<LoginResponseDto>.SuccessfulRespone(response, "Login successful with Google");
        }
    }
}
