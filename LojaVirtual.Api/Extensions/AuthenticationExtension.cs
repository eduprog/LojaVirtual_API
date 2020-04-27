using LojaVirtual.Api.Helpers.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Api.Extensions
{
    public static class AuthenticationExtension
    {
        private const string AUDIENCE = "lojavirtual.app";
        private const string ISSUER = "lojavirtual.api";

        public static void ConfigureService(this IServiceCollection service)
        {
            var signingConfigurations = new SigningConfigurations();
            service.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations()
            {
                Audience = AUDIENCE,
                Issuer = ISSUER,
                Seconds = int.Parse(TimeSpan.FromDays(1).TotalSeconds.ToString())
            };
            service.AddSingleton(tokenConfigurations);

            service.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.SigningCredentials.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Valida se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de expiração de um token (utilizado caso haja problemas de sincronismo de horário
                // entre diferentes computadores envolvidos em processo de comunicação
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            service.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            // Todas as requisições serão protegidas, caso não for, usar [AllowAnonymous]
            service.AddControllers(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
        }

        public static void Configure(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}