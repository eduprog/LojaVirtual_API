using LojaVirtual.Domain.Enums;
using MediatR;

namespace LojaVirtual.Domain.Commands.Banner.ListBannerByLocal
{
    public class ListBannerByLocalRequest : IRequest<ResponseGeneric>
    {
        public ListBannerByLocalRequest(EBannerLocal local)
        {
            Local = local;
        }

        public EBannerLocal Local { get; private set; }
    }
}
