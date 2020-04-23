using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Repositories.Map.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaVirtual.Infra.Repositories.Map
{
    public class BannerMap : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            MapBaseExtension.Map<Banner>(builder);
            builder.Property(x => x.Title).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Image).HasColumnType("varchar(400)").IsRequired();
            builder.Property(x => x.Url).HasColumnType("varchar(400)");
            builder.Property(x => x.Pos).HasColumnType("int").IsRequired();
            builder.Property(x => x.X).HasColumnType("int").IsRequired();
            builder.Property(x => x.Y).HasColumnType("int").IsRequired();
            builder.Property(x => x.Local).HasColumnType("int").IsRequired();
            builder.HasOne(x => x.UserCreate).WithMany().HasForeignKey("UserCreateId");
        }
    }
}
