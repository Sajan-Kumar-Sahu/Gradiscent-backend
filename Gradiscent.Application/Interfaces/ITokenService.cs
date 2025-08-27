using Gradiscent.Domain.Models;

namespace Gradiscent.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user, IList<string> role);
    }
}
