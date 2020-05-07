using System.Threading;
using System.Threading.Tasks;
using LojaVirtual.Domain.Commands.Base;
using LojaVirtual.Domain.Interfaces.Repositories;
using LojaVirtual.Domain.Interfaces.Transactions;
using MediatR;

namespace LojaVirtual.Domain.Commands.Cart.ChangeQuantity
{
    public class ChangeQuantityHandler : HandlerBase, IRequestHandler<ChangeQuantityRequest, ResponseGeneric>
    {
        private readonly IUserRepository userRepository;
        private readonly ICartRepository cartRepository;
        private readonly IUnitOfWork unitOfWork;

        public ChangeQuantityHandler(
            IUserRepository userRepository,
            ICartRepository cartRepository,
            IUnitOfWork unitOfWork
        )
        {
            this.userRepository = userRepository;
            this.cartRepository = cartRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseGeneric> Handle(ChangeQuantityRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                AddNotifications(request.Notifications);
                return new ResponseGeneric(false, "Não foi possível adicionar/remover o item do carrinho! Item inválido.", request.Notifications);
            }

            Entities.User user = this.userRepository.GetBy(x => x.Id == request.UserId);

            if (user == null)
            {
                AddNotification("User", "Usuário inválido");
                return new ResponseGeneric(false, "Não foi possível adicionar/remover o item do carrinho! Usuário inválido.", Notifications);
            }

            Entities.Cart cartAdd = this.cartRepository.GetBy(x => x.Id == request.Id, x => x.User);

            if (cartAdd == null)
            {
                AddNotification("Cart", "Item inválido");
                return new ResponseGeneric(false, "Não foi possível adicionar/remover o item do carrinho! Item não encontrado.", Notifications);
            }

            if (cartAdd.User.Id != user.Id)
            {
                AddNotification("User", "Operação não permitida");
                return new ResponseGeneric(false, "Não foi possível adicionar/remover o item do carrinho! Usuário inválido.", Notifications);
            }



            if (request.Operation == Enums.ECartOperation.Add)
            {
                cartAdd.incrementQuantity();
            }
            else if (request.Operation == Enums.ECartOperation.Rem)
            {
                if (cartAdd.Quantity == 1)
                {
                    AddNotification("User", "Operação não permitida");
                    return new ResponseGeneric(false, "Não foi possível adicionar/remover o item do carrinho! Quantidade é 1.", Notifications);
                }

                cartAdd.decrementQuantity();
            }

            this.cartRepository.Update(cartAdd);

            if (await this.unitOfWork.SaveChanges() == 0)
            {
                AddNotification("Cart", "Erro ao adicionar/remover o item do carrinho");
                return new ResponseGeneric(false, "Não foi possível adicionar/remover o item do carrinho!", Notifications);
            }

            var response = new ResponseGeneric(true, "Item adicionar/removido com sucesso do carrinho", null);

            return await Task.FromResult(response);
        }
    }
}