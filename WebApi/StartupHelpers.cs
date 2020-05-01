using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using WebApi.Domain.IdentityModels;
using WebApi.Entities;

namespace WebApi
{
    public static class StartupHelpers
    {
        public static async Task CreateUserRoles(this IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (!await roleManager.RoleExistsAsync(Roles.SysAdmin))
                await roleManager.CreateAsync(new ApplicationRole(Roles.SysAdmin));

            if (!await roleManager.RoleExistsAsync(Roles.Employee))
                await roleManager.CreateAsync(new ApplicationRole(Roles.Employee));

            if (!await roleManager.RoleExistsAsync(Roles.HR_Worker))
                await roleManager.CreateAsync(new ApplicationRole(Roles.HR_Worker));

            if (!await roleManager.RoleExistsAsync(Roles.WorkPlaceLeader))
                await roleManager.CreateAsync(new ApplicationRole(Roles.WorkPlaceLeader));

            var user = new ApplicationUser
            {
                Email = "admin@test.com",
                UserName = "admin@test.com",
                Specialty = "SysAdmin",
                Name = "ADMIN",
                Surname = "ADMIN",
                Title = "Sys",
                BirthPlace = "Domain",
                AddressOfPermanentResidence = "Domain",
                Citizenship = "IT",
                Salary = 1,
                NumberOfVacationDays = 1,
                BirthCertificateNumber = "00000000/0000",
                EmailConfirmed = true,
                LockoutEnabled = false
            };

            var existingUser = await userManager.FindByEmailAsync(user.Email);

            if (existingUser is null)
            {
                await userManager.CreateAsync(user, "admin123");
                await userManager.AddToRoleAsync(user, Roles.SysAdmin);
            }
        }
    }
}
