using System.Threading;
using System.Threading.Tasks;
using LojaVirtual.Domain.Commands.Base;
using LojaVirtual.Domain.Interfaces.Repositories;
using LojaVirtual.Domain.Interfaces.Services;
using MediatR;

namespace LojaVirtual.Domain.Commands.Order.FinishOrder
{
    public class FinishOrderHandler : HandlerBase, IRequestHandler<FinishOrderRequest, ResponseGeneric>
    {
        private readonly ICouponRepository couponRepository;
        private readonly IMessageBrokerService messageBrokerService;

        public FinishOrderHandler(
            ICouponRepository couponRepository,
            IMessageBrokerService messageBrokerService
        )
        {
            this.couponRepository = couponRepository;
            this.messageBrokerService = messageBrokerService;
        }
        
        public async Task<ResponseGeneric> Handle(FinishOrderRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                AddNotifications(request.Notifications);
                return new ResponseGeneric(false, "Não foi possível finalizar o pedido!", request.Notifications);
            }

            this.messageBrokerService.sendMessage("orderProcessing", request);

            var response = new ResponseGeneric(true, "Pedido está sendo processado! Aguarde a confirmação do pedido.", null);

            return await Task.FromResult(response);            
        }
    }
}