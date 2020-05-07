using Flunt.Validations;
using LojaVirtual.Domain.Commands.Base;
using MediatR;

namespace LojaVirtual.Domain.Commands.Coupon.GetCoupon
{
    public class GetCouponRequest : RequestBase, IRequest<ResponseGeneric>
    {
        public string Reference { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Reference, "Reference", "Cupom de desconto é obrigatório")
            );
        }
    }
}