using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Repositories.Map.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaVirtual.Infra.Repositories.Map
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            MapBaseExtension.Map<Category>(builder);
            builder.Property(x => x.Title).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Icon).HasColumnType("varchar(400)").IsRequired();
            builder.HasOne(x => x.UserCreate).WithMany().HasForeignKey("UserCreateId");
        }
    }
}
