using LojaVirtual.Domain.Interfaces.Repositories;
using LojaVirtual.Infra.Repositories;
using LojaVirtual.Infra.Repositories.Base;
using LojaVirtual.Infra.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace LojaVirtual.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ConfigureService(this IServiceCollection service)
        {

            service.AddDbContext<DatabaseContext>();

            service.AddScoped<IUnitOfWork, UnitOfWork>();

            service.AddScoped<IBannerRepository, BannerRepository>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUserTokenRepository, UserTokenRepository>();
            service.AddScoped<IPlaceRepository, PlaceRepository>();

        }
    }
}
