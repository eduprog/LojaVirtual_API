using LojaVirtual.Domain.Commands.Base;
using LojaVirtual.Domain.Interfaces.Repositories;
using LojaVirtual.Domain.Interfaces.Transactions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Commands.Cart.AddProductInCart
{
    public class AddProductInCartHandler : HandlerBase, IRequestHandler<AddProductInCartRequest, ResponseGeneric>
    {
        private readonly ICartRepository cartRepository;
        private readonly IProductRepository productRepository;
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public AddProductInCartHandler(
            ICartRepository cartRepository,
            IProductRepository productRepository,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork
        )
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseGeneric> Handle(AddProductInCartRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                AddNotifications(request.Notifications);
                return new ResponseGeneric(false, "Não foi possível adicionar o item no carrinho! Item inválido.", request.Notifications);
            }

            Entities.Product product = this.productRepository.GetBy(x => x.Id == request.ProductId);

            if (product == null)
            {
                AddNotification("Product", "Produto inválido");
                return new ResponseGeneric(false, "Não foi possível adicionar o item no carrinho! Produto inválido.", Notifications);
            }

            Entities.User user = this.userRepository.GetBy(x => x.Id == request.UserId);

            if (user == null)
            {
                AddNotification("User", "Usuário inválido");
                return new ResponseGeneric(false, "Não foi possível adicionar o item no carrinho! Usuário inválido.", Notifications);
            }

            Entities.Cart cartAdd = this.cartRepository.GetBy(x => x.Product.Id == product.Id && x.User.Id == user.Id && x.Status == Enums.ECartStatus.Added && x.Size == request.Size, x => x.Product);

            if (cartAdd == null)
            {
                cartAdd = new Entities.Cart(request.Size, request.Quantity, request.Origin);
                cartAdd.setProduct(product);

                cartAdd.setUser(user);

                this.cartRepository.Add(cartAdd);

                if (cartAdd == null)
                {
                    AddNotification("Cart", "Carrinho inválido");
                    return new ResponseGeneric(false, "Não foi possível adicionar o item no carrinho! Item inválido.", Notifications);
                }
            }
            else
            {
                cartAdd.incrementQuantity();

                this.cartRepository.Update(cartAdd);
            }


            if (await this.unitOfWork.SaveChanges() == 0)
            {
                AddNotification("Cart", "Erro ao salvar item no carrinho");
                return new ResponseGeneric(false, "Não foi possível adicionar o item no carrinho!", Notifications);
            }


            cartAdd.User.SetPassword(null);

            AddProductInCartResponse modelResponse = new AddProductInCartResponse(cartAdd.Id, cartAdd.Size, cartAdd.Quantity, cartAdd.Product.Id, cartAdd.Origin);

            var response = new ResponseGeneric(true, "Item adicionado com sucesso ao carrinho", modelResponse);

            return await Task.FromResult(response);
        }
    }
}
