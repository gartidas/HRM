using AutoMapper;
using FluentValidation.AspNetCore;
using MachineRepairScheduler.WebApi.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WebApi.Data;
using WebApi.Entities;
using WebApi.Filters;
using WebApi.Options;
using WebApi.Services;

namespace WebApi
{
    public class Installers
    {
        public static void AuthenticationInstaller(IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind("JwtSettings", jwtSettings);

            services.AddSingleton(jwtSettings);
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IRequestTokenInfo>(x =>
            {
                var httpContext = x.GetRequiredService<IHttpContextAccessor>().HttpContext;
                return new RequestTokenInfo(httpContext);
            });

            var tokenValidationParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero // remove if causes problems
            };

            services.AddSingleton(tokenValidationParams);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = tokenValidationParams;
            });
        }
        public static void DbInstaller(IServiceCollection services, IConfiguration configuration)
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
        public static void MediatorInstaller(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Startup).Assembly);

            var classTypes = typeof(Startup).Assembly.ExportedTypes.Select(x => x.GetTypeInfo()).Where(x => x.IsClass && !x.IsAbstract);

            foreach (var type in classTypes)
            {
                var interfaces = type.ImplementedInterfaces
                    .Select(x => x.GetTypeInfo())
                    .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

                foreach (var handlerType in interfaces)
                    services.AddTransient(handlerType.AsType(), type.AsType());
            }
        }
        public static void MvcInstaller(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc()
               .AddMvcOptions(opt => opt.Filters.Add(typeof(ValidationFilter)))
               .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>())
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapper(typeof(Startup));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }
        public static void SwaggerInstaller(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Human Resources Module API", Version = "v1" });

                x.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                x.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[0] }
                });
            });

            //There were some conflicts for using same name for Command or Response classes
            services.ConfigureSwaggerGen(x => x.CustomSchemaIds(xx => xx.FullName));
        }
    }
}
