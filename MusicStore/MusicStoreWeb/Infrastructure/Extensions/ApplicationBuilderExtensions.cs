using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicStoreWeb.Data;
using MusicStoreWeb.Infrastructure.Common;
using System.Threading.Tasks;

namespace MusicStoreWeb.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<MusicStoreDbContext>().Database.Migrate();

                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                Task.Run(async () =>
                {
                    var adminName = WebConstants.AdministratingRole;

                    var roleExist = await roleManager.RoleExistsAsync(adminName);

                    if (!roleExist)
                    {
                        var role = new IdentityRole { Name = adminName };

                        await roleManager.CreateAsync(role);
                    }

                    var adminEmail = WebConstants.AdministratingEmail;
                    var adminExist = await userManager.FindByEmailAsync(adminEmail);
                    var user = await userManager.FindByEmailAsync("test1@test.bg");

                    if (adminExist == null)
                    {
                        var adminUser = new IdentityUser
                        {
                            Email = adminEmail,
                            UserName = adminEmail
                        };

                        await userManager.CreateAsync(adminUser, WebConstants.AdministratingPassword);

                        await userManager.AddToRoleAsync(adminUser, adminName);
                    }
                })
                .Wait();
            }

            return app;
        }
    }
}
