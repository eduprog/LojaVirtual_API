using Flunt.Validations;
using LojaVirtual.Domain.Commands.Base;
using MediatR;
using System;

namespace LojaVirtual.Domain.Commands.Cart.AddProductInCart
{
    public class AddProductInCartRequest : RequestBase, IRequest<ResponseGeneric>
    {
        public Guid UserId { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Enums.ECartOrigin Origin { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(UserId.ToString(), "User", "Usuário é obrigatório")
                .IsNotNullOrEmpty(Size, "Size", "Tamanho é obrigatório")
                .HasMaxLen(Size, 200, "Size", "Tamanho deve conter no máximo 20 caracteres")
                .IsNotNullOrEmpty(Quantity.ToString(), "Quantity", "Quantidade é obrigatória")
                .IsNotNullOrEmpty(ProductId.ToString(), "Product", "Produto é obrigatório")
                .IsNotNullOrEmpty(Origin.ToString(), "Origin", "Origem é obrigatório")
            );
        }
    }
}
