using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories;
using LojaVirtual.Infra.Repositories.Base;
using System;

namespace LojaVirtual.Infra.Repositories
{
    public class PlaceRepository : RepositoryBase<Place, Guid>, IPlaceRepository
    {
        public PlaceRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
