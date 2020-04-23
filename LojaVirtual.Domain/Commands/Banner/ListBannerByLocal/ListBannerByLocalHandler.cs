using LojaVirtual.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Commands.Banner.ListBannerByLocal
{
    public class ListBannerByLocalHandler : IRequestHandler<ListBannerByLocalRequest, ResponseGeneric>
    {
        private readonly IBannerRepository bannerRepository;

        public ListBannerByLocalHandler(
            IBannerRepository bannerRepository    
        )
        {
            this.bannerRepository = bannerRepository;
        }

        public async Task<ResponseGeneric> Handle(ListBannerByLocalRequest request, CancellationToken cancellationToken)
        {
            // validar

            var list = this.bannerRepository.ListAndOrderBy(x => x.Local == request.Local, x => x.Pos);

            var response = new ResponseGeneric(true, "Banners listados com sucesso", list);

            return await Task.FromResult(response);
        }
    }
}
