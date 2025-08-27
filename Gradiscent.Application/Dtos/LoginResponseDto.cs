namespace Gradiscent.Application.Dtos
{
    public class LoginResponseDto
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
