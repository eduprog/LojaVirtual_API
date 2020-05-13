using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Repositories.Map.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Infra.Repositories.Map
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            MapBaseExtension.Map<OrderItem>(builder);
            builder.Property(x => x.Size).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.HasOne(x => x.Product).WithMany().HasForeignKey("ProductId");
            builder.HasOne(x => x.Order).WithMany().HasForeignKey("OrderId");
        }
    }
}
