using System;
using System.Threading;
using System.Threading.Tasks;
using LojaVirtual.Domain.Commands.Base;
using LojaVirtual.Domain.Interfaces.Repositories;
using MediatR;

namespace LojaVirtual.Domain.Commands.Coupon.GetCoupon
{
    public class GetCouponHandler : HandlerBase, IRequestHandler<GetCouponRequest, ResponseGeneric>
    {
        private readonly ICouponRepository couponRepository;

        public GetCouponHandler(
            ICouponRepository couponRepository
        )
        {
            this.couponRepository = couponRepository;
        }

        public async Task<ResponseGeneric> Handle(GetCouponRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                AddNotifications(request.Notifications);
                return new ResponseGeneric(false, "Não foi possível consultar o cupom de desconto! Cupom inválido.", request.Notifications);
            }

            Entities.Coupon coupon = this.couponRepository.GetBy(x => x.Reference.ToLower() == request.Reference.ToLower());
            coupon.Validate();

            if (coupon.Invalid)
            {
                return new ResponseGeneric(false, "Não foi possível consultar o cupom de desconto!", coupon.Notifications);
            }

            var response = new ResponseGeneric(true, "Cupom de desconto aplicado com sucesso!", new { Reference = coupon.Reference, Percent = coupon.Percent });

            return await Task.FromResult(response);
        }
    }
}