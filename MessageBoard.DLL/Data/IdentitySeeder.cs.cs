using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MessageBoard.DLL.Entities;
using System;

namespace MessageBoard.DLL.Data
{
    public static class IdentitySeeder
    {
        // Seed roles and example users. Call this after the app has built its service provider.
        public static async Task SeedAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Define roles to ensure exist
            string[] roles = new[] { "Admin", "Member" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Create default admin user
            var adminUser = await userManager.FindByNameAsync("admin");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    DisplayName = "Administrator",
                    EmailConfirmed = true
                };

                // NOTE: Use a stronger password or load from configuration in production
                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Create a default normal member
            var normalUser = await userManager.FindByNameAsync("member");
            if (normalUser == null)
            {
                normalUser = new ApplicationUser
                {
                    UserName = "member",
                    Email = "member@example.com",
                    DisplayName = "Default Member",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(normalUser, "Member123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(normalUser, "Member");
                }
            }
        }
    }
}
