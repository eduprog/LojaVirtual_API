using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using LojaVirtual.Api.Hubs;
using LojaVirtual.Domain.Commands.Order.FinishOrder;
using LojaVirtual.Domain.Commands.Order.ListOrdersByUser;
using LojaVirtual.Domain.Commands.Order.UpdateStatusOrder;
using LojaVirtual.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace LojaVirtual.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHubContext<OrdersHub> ordersHubContext;

        public OrderController(
            IMediator mediator,
            IHubContext<OrdersHub> ordersHubContext
        )
        {
            this._mediator = mediator;
            this.ordersHubContext = ordersHubContext;
        }

        [HttpPost("finish")]
        public async Task<IActionResult> Finish([FromBody] FinishOrderRequest request)
        {
            try
            {
                request.UserId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid).Value);
                var response = await _mediator.Send(request, CancellationToken.None);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{order_id}/change-status/{status_id}")]
        public async Task<IActionResult> ChangeStatus(Guid order_id, EOrderStatus status_id)
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.PrimarySid).Value;
                var request = new UpdateStatusOrderRequest(order_id, status_id);
                var response = await _mediator.Send(request, CancellationToken.None);

                if (response.Success == true)
                {
                    var requestList = new ListOrdersByUserRequest(Guid.Parse(userId));
                    var responseList = await _mediator.Send(requestList, CancellationToken.None);

                    await this.ordersHubContext.Clients.Group(userId).SendAsync("ReceiveOrders", responseList);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}