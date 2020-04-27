using LojaVirtual.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Commands.Places.ListPlaces
{
    public class ListPlacesHandler : IRequestHandler<ListPlacesRequest, ResponseGeneric>
    {
        private readonly IPlaceRepository placeRepository;

        public ListPlacesHandler(IPlaceRepository placeRepository)
        {
            this.placeRepository = placeRepository;
        }

        public async Task<ResponseGeneric> Handle(ListPlacesRequest request, CancellationToken cancellationToken)
        {
            // validar

            var list = this.placeRepository.ListAndOrderBy(x => x.VisibleOnApp == true, x => x.Title);

            var response = new ResponseGeneric(true, "Lojas listadas com sucesso", list);

            return await Task.FromResult(response);
        }
    }
}
