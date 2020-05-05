using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Repositories.Map.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Infra.Repositories.Map
{
    public class CartMap : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            MapBaseExtension.Map<Cart>(builder);
            builder.Property(x => x.Size).HasColumnType("varchar(20)");
            builder.Property(x => x.Quantity).IsRequired();
            builder.HasOne(x => x.User).WithMany().HasForeignKey("UserId");
            builder.HasOne(x => x.Product).WithMany().HasForeignKey("ProductId");
            builder.Property(x => x.Origin).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
