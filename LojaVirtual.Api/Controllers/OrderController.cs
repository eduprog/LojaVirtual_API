using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using LojaVirtual.Domain.Commands.Order.FinishOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(
            IMediator mediator
        )
        {
            this._mediator = mediator;
        }

        [HttpPost]
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
    }
}