using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRoleAndUserManager.Data
{
    public static class IdentitySeed
    {
        public static void CreateAdminRoleAndAccount(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            CreateAdminRoleAndAccountAsync(serviceProvider, configuration).Wait();
        }
        public static async Task CreateAdminRoleAndAccountAsync(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            ApplicationDbContext context = serviceProvider
                .CreateScope().ServiceProvider
                .GetRequiredService<ApplicationDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<AppUser> userManager = serviceProvider
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<AppUser>>();

            RoleManager<AppRole> roleManager = serviceProvider
                .CreateScope().ServiceProvider
                .GetRequiredService<RoleManager<AppRole>>();

            string username = configuration["Data:AdminUser:Name"] ?? "admin";
            string email = configuration["Data:AdminUser:Email"] ?? "admin@example.com";
            string password = configuration["Data:AdminUser:Password"] ?? "secret";
            string roleName = configuration["Data:AdminUser:Role"] ?? "Admins";
            string roleFaName = configuration["Data:AdminUser:RoleFaName"] ?? "مدیر سیستم";

            if (await userManager.FindByNameAsync(username) == null)
            {
                if (await roleManager.FindByNameAsync(roleName) == null)
                {
                    await roleManager.CreateAsync(new AppRole(roleName, roleFaName, "seed"));
                }

                AppUser user = new AppUser { UserName = username, Email = email, FirstName = "نام", LastName = "نام خانوادگی" };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }

        //private const string adminUser = "admin";
        //private const string adminPassword = "123";
        //public static async void EnsurePopulated(IApplicationBuilder app)
        //{
        //    ApplicationDbContext context = app.ApplicationServices
        //        .CreateScope().ServiceProvider
        //        .GetRequiredService<ApplicationDbContext>();

        //    if (context.Database.GetPendingMigrations().Any())
        //    {
        //        context.Database.Migrate();
        //    }

        //    UserManager<AppUser> userManager = app.ApplicationServices
        //        .CreateScope().ServiceProvider
        //        .GetRequiredService<UserManager<AppUser>>();

        //    var user = await userManager.FindByIdAsync(adminUser);
        //    if (user == null)
        //    {
        //        user = new AppUser();
        //        user.UserName = adminUser;
        //        user.Email = "admin@example.com";
        //        user.PhoneNumber = "";
        //        await userManager.CreateAsync(user, adminPassword);
        //    }
        //}
    }
}
