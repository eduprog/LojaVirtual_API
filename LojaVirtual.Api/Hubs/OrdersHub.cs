using LojaVirtual.Domain.Commands.Order.ListOrdersByUser;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Api.Hubs
{
    public class OrdersHub : Hub
    {
        private readonly IMediator mediator;

        public OrdersHub(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task ReceiveOrders()
        {
            string ConnectionId = Context.ConnectionId;
            string GroupName = Context.User.FindFirst(ClaimTypes.PrimarySid).Value;

            await Groups.AddToGroupAsync(ConnectionId, Context.User.FindFirst(ClaimTypes.PrimarySid).Value);

            // listar todos os pedidos do usuário, ordenados por mais recente
            var request = new ListOrdersByUserRequest(Guid.Parse(Context.User.FindFirst(ClaimTypes.PrimarySid).Value));
            var response = await mediator.Send(request, CancellationToken.None);

            await Clients.Group(GroupName).SendAsync("ReceiveOrders", response);
        }

        public async Task RemoveUserGroup()
        {
            string ConnectionId = Context.ConnectionId;
            string GroupName = Context.User.FindFirst(ClaimTypes.PrimarySid).Value;

            await Groups.RemoveFromGroupAsync(ConnectionId, GroupName);
        }

    }
}
