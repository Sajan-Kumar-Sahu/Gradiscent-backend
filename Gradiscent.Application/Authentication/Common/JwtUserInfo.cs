namespace Gradiscent.Application.Authentication.Common
{
    public class JwtUserInfo
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string? FullName { get; set; }
    }
}
