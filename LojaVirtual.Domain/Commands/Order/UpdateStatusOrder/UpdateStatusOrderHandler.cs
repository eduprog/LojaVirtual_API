using System.Threading;
using System.Threading.Tasks;
using LojaVirtual.Domain.Commands.Base;
using LojaVirtual.Domain.Interfaces.Repositories;
using LojaVirtual.Domain.Interfaces.Transactions;
using MediatR;

namespace LojaVirtual.Domain.Commands.Order.UpdateStatusOrder
{
    public class UpdateStatusOrderHandler : HandlerBase, IRequestHandler<UpdateStatusOrderRequest, ResponseGeneric>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateStatusOrderHandler(
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork
        )
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseGeneric> Handle(UpdateStatusOrderRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                AddNotifications(request.Notifications);
                return new ResponseGeneric(false, "Não foi possível atualizar o status do pedido!", request.Notifications);
            }

            Entities.Order order = this.orderRepository.GetBy(x => x.Id == request.OrderId);
            order.SetStatus(request.StatusId);

            this.orderRepository.Update(order);

            if (await this.unitOfWork.SaveChanges() == 0)
            {
                AddNotification("Order", "Erro ao salvar o status do pedido");
                return new ResponseGeneric(false, "Não foi possível atualizar o status do pedido!", Notifications);
            }

            var response = new ResponseGeneric(true, "Status do pedido atualizado com sucesso!", null);

            return await Task.FromResult(response);
        }
    }
}