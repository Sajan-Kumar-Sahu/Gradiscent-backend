using Gradiscent.Application.Common;
using Gradiscent.Application.Dtos;
using Gradiscent.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Data;
using System.Text;

namespace Gradiscent.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IExternalAuthService _externalAuthService;

        public AuthController(IAuthService authService, IExternalAuthService externalAuthService)
        {
            _authService = authService;
            _externalAuthService = externalAuthService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.RegisterAsync(registerDto);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.LoginAsync(loginDto);
            if(!result.Success)
            {
                return Unauthorized(result.Message);
            }
            return Ok(result);
        }
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenRefreshRequestDto tokenRefreshRequest)
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            var result = await _authService.RefreshTokenAsync(tokenRefreshRequest.Token, ipAddress);
            if(!result.Success)
            {
                return Unauthorized(new {message = result.Message});
            }
            return Ok(result);
        }

        [HttpGet("verify")]
        public async Task<IActionResult> VerifyEmail(string userId, string token)
        {
            var decodedBytes = WebEncoders.Base64UrlDecode(token);
            var decodedToken = Encoding.UTF8.GetString(decodedBytes);

            var result = await _authService.VerifyEmailAsync(userId, decodedToken);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpGet("login-google")]
        public IActionResult LoginGoogle([FromQuery] string requestedRole)
        {
            var props = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse", "Auth", new { requestedRole })
            };
            return Challenge(props, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("signin-google")]
        public async Task<IActionResult> GoogleCallback([FromQuery] string requestedRole)
        {
            if(string.IsNullOrEmpty(requestedRole))
            {
                return BadRequest(ApiResponse<string>.FailedResponse("Role is required."));
            }
            var response = await _externalAuthService.LoginWithGoogleAsync(requestedRole);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout([FromBody] string refreshToken)
        {
            await _authService.LogoutAsync(refreshToken);
            return Ok(new { message = "Logged out successfully" });
        }

        [Authorize]
        [HttpGet("test")]
        public string Test() {
            return "test successful";
        }
    }
}
