using LojaVirtual.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaVirtual.Infra.Repositories.Map.Base
{
    public static class MapBaseExtension
    {
        public static void Map<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : EntityBase
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate).IsRequired();
        }
    }
}
