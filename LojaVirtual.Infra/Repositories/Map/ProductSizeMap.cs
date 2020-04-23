using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Repositories.Map.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaVirtual.Infra.Repositories.Map
{
    public class ProductSizeMap : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            MapBaseExtension.Map<ProductSize>(builder);
            builder.Property(x => x.Size).HasColumnType("varchar(10)").IsRequired();
            //builder.HasOne(x => x.Product).WithMany().HasForeignKey("ProductId");
            builder.HasOne(x => x.UserCreate).WithMany().HasForeignKey("UserCreateId");
        }
    }
}
