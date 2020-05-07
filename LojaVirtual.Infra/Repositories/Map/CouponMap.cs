using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Repositories.Map.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaVirtual.Infra.Repositories.Map
{
    public class CouponMap : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            MapBaseExtension.Map<Coupon>(builder);
            builder.Property(x => x.Reference).HasColumnType("varchar(80)").IsRequired();
            builder.Property(x => x.Percent).IsRequired();
            builder.Property(x => x.Active).IsRequired();
            builder.Property(x => x.ExpirationDate);
        }
    }
}