using LojaVirtual.Domain.Commands.Base;
using LojaVirtual.Domain.Interfaces.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Commands.Order.ListOrdersByUser
{
    public class ListOrdersByUserHandler : HandlerBase, IRequestHandler<ListOrdersByUserRequest, ResponseGeneric>
    {
        private readonly IUserRepository userRepository;
        private readonly IOrderRepository orderRepository;

        public ListOrdersByUserHandler(
            IUserRepository userRepository,
            IOrderRepository orderRepository
        )
        {
            this.userRepository = userRepository;
            this.orderRepository = orderRepository;
        }

        public async Task<ResponseGeneric> Handle(ListOrdersByUserRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                AddNotifications(request.Notifications);
                return new ResponseGeneric(false, "Não foi possível listar os pedidos!", request.Notifications);
            }

            Entities.User user = this.userRepository.GetBy(x => x.Id == request.UserId);

            if (user == null)
            {
                AddNotification("User", "Usuário inválido");
                return new ResponseGeneric(false, "Não foi possível listar o carrinho! Usuário inválido.", Notifications);
            }

            IQueryable<Entities.Order> list = this.orderRepository.ListAndOrderBy(x => x.User.Id == user.Id, x => x.CreateDate, false);

            var response = new ResponseGeneric(true, "Pedidos listados com sucesso!", list);

            return await Task.FromResult(response);
        }
    }

}
