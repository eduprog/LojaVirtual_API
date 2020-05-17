using System;
using Flunt.Validations;
using LojaVirtual.Domain.Commands.Base;
using LojaVirtual.Domain.Enums;
using MediatR;

namespace LojaVirtual.Domain.Commands.Order.UpdateStatusOrder
{
    public class UpdateStatusOrderRequest : RequestBase, IRequest<ResponseGeneric>
    {
        public UpdateStatusOrderRequest(Guid order_id, EOrderStatus status_id)
        {
            this.OrderId = order_id;
            this.StatusId = status_id;
        }

        public Guid OrderId { get; set; }
        public EOrderStatus StatusId { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(OrderId.ToString(), "Order", "Pedido é obrigatório")
                .IsNotNullOrEmpty(StatusId.ToString(), "Status", "Status é obrigatório")
            );
        }
    }
}