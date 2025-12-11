namespace Gradiscent.Application.Authentication.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }
        public UserProfileResponseDto User { get; set; }
    }
}
