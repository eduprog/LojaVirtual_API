using System;
using System.Threading;
using System.Threading.Tasks;
using LojaVirtual.Domain.Commands.Coupon.GetCoupon;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CouponController(
            IMediator mediator
        )
        {
            this._mediator = mediator;
        }

        [HttpPost("verify-coupon")]
        public async Task<IActionResult> VerifyCoupon([FromBody] GetCouponRequest request)
        {
            try
            {
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