using LojaVirtual.Domain.Interfaces.Repositories;
using LojaVirtual.Domain.Interfaces.Services;
using LojaVirtual.Domain.Interfaces.Transactions;
using LojaVirtual.Infra.Repositories;
using LojaVirtual.Infra.Repositories.Base;
using LojaVirtual.Infra.Services;
using LojaVirtual.Infra.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace LojaVirtual.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ConfigureService(this IServiceCollection service)
        {

            service.AddDbContext<DatabaseContext>();

            service.AddTransient<IUnitOfWork, UnitOfWork>();

            service.AddTransient<IBannerRepository, BannerRepository>();
            service.AddTransient<ICategoryRepository, CategoryRepository>();
            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IUserTokenRepository, UserTokenRepository>();
            service.AddTransient<IPlaceRepository, PlaceRepository>();
            service.AddTransient<ICartRepository, CartRepository>();
            service.AddTransient<ICouponRepository, CouponRepository>();
            service.AddTransient<IOrderRepository, OrderRepository>();

            service.AddTransient<IMessageBrokerService, RabbitMqService>();

        }
    }
}
