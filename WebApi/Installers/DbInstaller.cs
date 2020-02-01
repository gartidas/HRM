using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Data;
using WebApi.Entities;

namespace MachineRepairScheduler.WebApi.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("ConnectionString")));

            services.AddIdentity<ApplicationUser, ApplicationRole>(o =>
             {
                 o.Password.RequiredLength = 8;
                 o.Password.RequireDigit = true;
                 o.Password.RequireUppercase = false;
                 o.Password.RequireNonAlphanumeric = false;
                 o.User.RequireUniqueEmail = true;
             })
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();
        }
    }
}
