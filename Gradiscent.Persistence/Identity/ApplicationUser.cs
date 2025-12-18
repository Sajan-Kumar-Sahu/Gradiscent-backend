using Microsoft.AspNetCore.Identity;

namespace Gradiscent.Persistence.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? TimeZone { get; set; }
        public string? Provider { get; set; }
        public string? ProviderId { get; set; }
        public bool IsExternalLogin { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
