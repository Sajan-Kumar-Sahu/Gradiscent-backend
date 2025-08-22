using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Gradiscent.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAsync(IServiceProvider ServiceProvider)
        {
            var roleManager = ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "STUDENT" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
