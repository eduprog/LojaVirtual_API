using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LojaVirtual.Domain.Commands.Base;
using LojaVirtual.Domain.Interfaces.Repositories;
using LojaVirtual.Domain.Interfaces.Transactions;
using MediatR;

namespace LojaVirtual.Domain.Commands.Cart.RemoveProduct
{
    public class RemoveProductHandler : HandlerBase, IRequestHandler<RemoveProductRequest, ResponseGeneric>
    {
        private readonly ICartRepository cartRepository;
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public RemoveProductHandler(
            ICartRepository cartRepository,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork
        )
        {
            this.cartRepository = cartRepository;
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseGeneric> Handle(RemoveProductRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                AddNotifications(request.Notifications);
                return new ResponseGeneric(false, "Não foi possível remover o item do carrinho! Item inválido.", request.Notifications);
            }

            Entities.User user = this.userRepository.GetBy(x => x.Id == request.UserId);

            if (user == null)
            {
                AddNotification("User", "Usuário inválido");
                return new ResponseGeneric(false, "Não foi possível remover o item do carrinho! Usuário inválido.", Notifications);
            }

            Entities.Cart cartAdd = this.cartRepository.GetBy(x => x.Id == request.Id, x => x.User);

            if (cartAdd == null)
            {
                AddNotification("Cart", "Item inválido");
                return new ResponseGeneric(false, "Não foi possível remover o item do carrinho! Item não encontrado.", Notifications);
            }

            if (cartAdd.User.Id != user.Id)
            {
                AddNotification("User", "Operação não permitida");
                return new ResponseGeneric(false, "Não foi possível remover o item do carrinho! Usuário inválido.", Notifications);
            }

            cartAdd.setRemoved();

            this.cartRepository.Update(cartAdd);

            if (await this.unitOfWork.SaveChanges() == 0)
            {
                AddNotification("Cart", "Erro ao remover o item do carrinho");
                return new ResponseGeneric(false, "Não foi possível remover o item do carrinho!", Notifications);
            }

            var response = new ResponseGeneric(true, "Item removido com sucesso do carrinho", null);

            return await Task.FromResult(response);
        }
    }
}