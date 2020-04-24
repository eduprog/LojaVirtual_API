using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace LojaVirtual.Api.Extensions
{
    public static class ControllersExtension
    {
        public static void ConfigureService(this IServiceCollection service)
        {
            service.AddControllers()
                    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }
    }
}
