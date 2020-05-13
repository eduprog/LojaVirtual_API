using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Repositories.Map.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaVirtual.Infra.Repositories.Map
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            MapBaseExtension.Map<Order>(builder);
            builder.Property(x => x.TotalProducts).IsRequired();
            builder.Property(x => x.TotalDiscount).IsRequired();
            builder.Property(x => x.TotalOrder).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasOne(x => x.User).WithMany().HasForeignKey("UseId");
        }
    }
}
