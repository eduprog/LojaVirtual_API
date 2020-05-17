using LojaVirtual.Api.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LojaVirtual.Api.Extensions
{
    public static class SignalRExtension
    {
        public static void ConfigureService(this IServiceCollection service)
        {
            service.AddSignalR();            
        }

        public static void Configure(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<OrdersHub>("/ordersHub");
            });
        }
    }

}
