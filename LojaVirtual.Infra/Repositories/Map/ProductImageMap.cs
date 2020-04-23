using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Repositories.Map.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaVirtual.Infra.Repositories.Map
{
    public class ProductImageMap : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            MapBaseExtension.Map<ProductImage>(builder);
            builder.Property(x => x.Image).HasColumnType("varchar(400)").IsRequired();
            //builder.HasOne(x => x.Product).WithMany().HasForeignKey("ProductId");
            builder.HasOne(x => x.UserCreate).WithMany().HasForeignKey("UserCreateId");
        }
    }
}
