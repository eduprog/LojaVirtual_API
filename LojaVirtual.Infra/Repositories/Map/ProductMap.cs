using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Repositories.Map.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaVirtual.Infra.Repositories.Map
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            MapBaseExtension.Map<Product>(builder);
            builder.Property(x => x.Title).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.Price).IsRequired();
            builder.HasOne(x => x.Category).WithMany().HasForeignKey("CategoryId");
            builder.HasOne(x => x.UserCreate).WithMany().HasForeignKey("UserCreateId");
        }
    }
}
