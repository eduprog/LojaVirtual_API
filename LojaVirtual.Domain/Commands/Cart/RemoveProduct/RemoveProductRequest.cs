using System;
using Flunt.Validations;
using LojaVirtual.Domain.Commands.Base;
using MediatR;

namespace LojaVirtual.Domain.Commands.Cart.RemoveProduct
{
    public class RemoveProductRequest : RequestBase, IRequest<ResponseGeneric>
    {
        public RemoveProductRequest(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Id.ToString(), "Cart", "Id é obrigatório")
                .IsNotNullOrEmpty(UserId.ToString(), "User", "Usuário é obrigatório")
            );
        }
    }
}