using LojaVirtual.Domain.Commands.Base;
using LojaVirtual.Domain.Interfaces.Repositories;
using LojaVirtual.Domain.Interfaces.Transactions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Commands.Order.ProcessOrder
{
    public class ProcessOrderHandler : HandlerBase, IRequestHandler<ProcessOrderRequest, ResponseGeneric>
    {
        private readonly ICartRepository cartRepository;
        private readonly ICouponRepository couponRepository;
        private readonly IProductRepository productRepository;
        private readonly IUserRepository userRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProcessOrderHandler(
            ICartRepository cartRepository,
            ICouponRepository couponRepository,
            IProductRepository productRepository,
            IUserRepository userRepository,
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork
        )
        {
            this.cartRepository = cartRepository;
            this.couponRepository = couponRepository;
            this.productRepository = productRepository;
            this.userRepository = userRepository;
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseGeneric> Handle(ProcessOrderRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                AddNotifications(request.Notifications);
                return new ResponseGeneric(false, "Não foi possível processar o pedido!", request.Notifications);
            }

            Entities.User user = this.userRepository.GetBy(x => x.Id == request.UserId);

            if (user == null)
            {
                AddNotification("User", "Usuário inválido");
                return new ResponseGeneric(false, "Não foi possível processar o pedido!", Notifications);
            }

            Entities.Coupon coupon = this.couponRepository.GetBy(x => x.Reference.ToLower() == request.ReferenceDiscount.ToLower());
            coupon.Validate();

            if (coupon.Invalid)
            {
                return new ResponseGeneric(false, "Não foi possível consultar o cupom de desconto!", coupon.Notifications);
            }

            Entities.Order order = new Entities.Order(0, 0, 0, Enums.EOrderStatus.Processing);

            order.setUser(user);

            decimal totalProducts = 0;
            foreach (var item in request.Items)
            {
                Entities.Cart itemCart = this.cartRepository.GetBy(x => x.Id == item.Id);
                itemCart.setBuyed();
                this.cartRepository.Update(itemCart);

                Entities.Product product = this.productRepository.GetBy(x => x.Id == item.ProductId);

                if (product == null)
                {
                    AddNotification("Product", "Produto não encontrado!");
                    return new ResponseGeneric(false, "Não foi possível processar o pedido", Notifications);
                }

                totalProducts += item.Quantity * product.Price;

                Entities.OrderItem itemOrder = new Entities.OrderItem(item.Size, item.Quantity, product.Price);
                itemOrder.setOrder(order);
                itemOrder.setProduct(product);

                order.Items.Add(itemOrder);
            }

            decimal totalDiscount = (totalProducts * coupon.Percent) / 100;
            decimal totalOrder = totalProducts - totalDiscount;

            order.SetTotalProducts(totalProducts);
            order.SetTotalDiscount(totalDiscount);
            order.SetTotalOrder(totalOrder);

            this.orderRepository.Add(order);

            if (await this.unitOfWork.SaveChanges() == 0)
            {
                AddNotification("Order", "Erro ao salvar processamento do pedido");
                return new ResponseGeneric(false, "Não foi possível processar o pedido!", Notifications);
            }

            var response = new ResponseGeneric(true, "Pedido processado com sucesso! Aguarde a entrega do pedido.", null);

            return await Task.FromResult(response);
        }
    }
}
