using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using TravisBrownBlog.Models;

namespace TravisBrownBlog.Data
{
    public static class DataUtility
    {
        private const string _adminRole = "Administrator";

        private const string _modRole = "Moderator";

        private const string _adminEmail = "tbrown@Mailinator.com";

        private const string _modEmail = "tbmod@mailinator.com";


        public static string GetConnectionString(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            string? databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");


            return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
        }


        private static string BuildConnectionString(string databaseUrl)
        {
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');
            var builder = new NpgsqlConnectionStringBuilder()
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };

            return builder.ToString();
        }


        public static async Task ManageDataAsync(IServiceProvider svcProvider)
        {
            // Obtaining the necessary services based on the IServiceProvider paramater
            var dbContextSvc = svcProvider.GetRequiredService<ApplicationDbContext>();
            var userManagerSvc = svcProvider.GetRequiredService<UserManager<BlogUser>>();

            var configurationSvc = svcProvider.GetRequiredService<IConfiguration>();

            var roleManagerSvc = svcProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Align the database by checking migrations
            await dbContextSvc.Database.MigrateAsync();



            // Seed Default Roles
            await SeedRolesAsync(roleManagerSvc);


            // Seed Default Users
            await SeedUsersAsync(dbContextSvc,configurationSvc,userManagerSvc);
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(_adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(_adminRole));
            }

            if(!await roleManager.RoleExistsAsync(_modRole))
            {
                await roleManager.CreateAsync(new IdentityRole(_modRole));
            }
        }

        private static async Task SeedUsersAsync(ApplicationDbContext context, IConfiguration configuration, UserManager<BlogUser> userManager)
        {

            // SEED ADMIN    PASSWORDS ARE IN THE SECRETS JSON
            if (!context.Users.Any(u => u.Email == _adminEmail))
            {
                BlogUser adminUser = new()
                {
                    Email = _adminEmail,
                    UserName = _adminEmail,
                    FirstName = "Travis",
                    LastName = "Brown",
                    EmailConfirmed = true
                };


                await userManager.CreateAsync(adminUser, configuration["AdminPassword"] ?? Environment.GetEnvironmentVariable("AdminPassword"));
                await userManager.AddToRoleAsync(adminUser,_adminRole);
            }

            // SEED MODERATOR  PASSWORDS ARE IN THE SECRETS JSON
            if (!context.Users.Any(u => u.Email == _modEmail))
            {
                BlogUser modUser = new()
                {
                    Email = _modEmail,
                    UserName = _modEmail,
                    FirstName = "Jim",
                    LastName = "Bob",
                    EmailConfirmed = true
                };


                await userManager.CreateAsync(modUser, configuration["ModeratorPassword"] ?? Environment.GetEnvironmentVariable("ModeratorPassword"));
                await userManager.AddToRoleAsync(modUser, _modRole);
            }

        }

    }
}
