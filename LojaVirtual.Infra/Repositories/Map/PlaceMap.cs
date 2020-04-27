using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Repositories.Map.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Infra.Repositories.Map
{
    public class PlaceMap : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            MapBaseExtension.Map<Place>(builder);
            builder.Property(x => x.Title).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Telephone).HasColumnType("varchar(40)").IsRequired();
            builder.Property(x => x.Latitude).IsRequired();
            builder.Property(x => x.Longitude).IsRequired();
            builder.Property(x => x.Image).HasColumnType("varchar(400)").IsRequired();
            builder.Property(x => x.Address).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.VisibleOnApp).IsRequired().HasDefaultValue(false);
        }
    }
}
