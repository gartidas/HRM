﻿using MachineRepairScheduler.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using WebApi.Options;
using WebApi.Services;

namespace MachineRepairScheduler.WebApi.Installers
{
    public class AuthenticationInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
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
    }
}
