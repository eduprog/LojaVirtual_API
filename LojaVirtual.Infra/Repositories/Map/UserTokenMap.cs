using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Repositories.Map.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaVirtual.Infra.Repositories.Map
{
    public class UserTokenMap : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            MapBaseExtension.Map<UserToken>(builder);
            builder.Property(x => x.ExpirationDate).IsRequired();
            builder.Property(x => x.Token).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Active).IsRequired();
            builder.Property(x => x.AccessDate);
            builder.Property(x => x.Type).IsRequired();
            builder.HasOne(x => x.User).WithMany().HasForeignKey("UserId");
        }
    }
}
