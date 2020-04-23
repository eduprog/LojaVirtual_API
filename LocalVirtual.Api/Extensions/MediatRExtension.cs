using LojaVirtual.Domain.Commands.Banner.ListBannerByLocal;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LojaVirtual.Api.Extensions
{
    public static class MediatRExtension
    {
        public static void ConfigureService(this IServiceCollection service)
        {
            //service.AddMediatR(Assembly.GetExecutingAssembly());
            service.AddMediatR(typeof(Startup).GetTypeInfo().Assembly, typeof(ListBannerByLocalRequest).GetTypeInfo().Assembly);
        }
    }
}
