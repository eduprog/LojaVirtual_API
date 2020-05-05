using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flunt.Validations;
using LojaVirtual.Domain.Commands.Base;
using LojaVirtual.Domain.Interfaces.Repositories;
using MediatR;

namespace LojaVirtual.Domain.Commands.Cart.ListCart
{
    public class ListCartHandler : HandlerBase, IRequestHandler<ListCartRequest, ResponseGeneric>
    {
        private readonly IUserRepository userRepository;
        private readonly ICartRepository cartRepository;

        public ListCartHandler(
            IUserRepository userRepository,
            ICartRepository cartRepository
        )
        {
            this.userRepository = userRepository;
            this.cartRepository = cartRepository;
        }

        public async Task<ResponseGeneric> Handle(ListCartRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                AddNotifications(request.Notifications);
                return new ResponseGeneric(false, "Não foi possível listar o carrinho!", request.Notifications);
            }

            Entities.User user = this.userRepository.GetBy(x => x.Id == request.UserId);

            if (user == null)
            {
                AddNotification("User", "Usuário inválido");
                return new ResponseGeneric(false, "Não foi possível listar o carrinho! Usuário inválido.", Notifications);
            }

            IQueryable<Entities.Cart> list = this.cartRepository.ListAndOrderBy(x => x.User.Id == user.Id && x.Status == Enums.ECartStatus.Added, x => x.CreateDate, false, x => x.Product.Images);

            var response = new ResponseGeneric(true, "Carrinho listado com sucesso!", list);

            return await Task.FromResult(response);
        }
    }
}