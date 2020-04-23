using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Api.Extensions
{
    public static class CorsExtension
    {
        public static void ConfigureService(this IServiceCollection service)
        {
            service.AddCors();
        }

        public static void Configure(this IApplicationBuilder app)
        {
            app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
        }
    }
}
