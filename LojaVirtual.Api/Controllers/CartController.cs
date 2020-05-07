using LojaVirtual.Api.Controllers.Base;
using LojaVirtual.Domain.Commands.Cart.AddProductInCart;
using LojaVirtual.Domain.Commands.Cart.ChangeQuantity;
using LojaVirtual.Domain.Commands.Cart.ListCart;
using LojaVirtual.Domain.Commands.Cart.RemoveProduct;
using LojaVirtual.Domain.Enums;
using LojaVirtual.Domain.Interfaces.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : BaseController
    {
        private readonly IMediator _mediator;

        public CartController(
            IMediator mediator,
            IUnitOfWork unitOfWork
        ) : base(unitOfWork)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var request = new ListCartRequest();
                request.UserId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid).Value);

                var response = await _mediator.Send(request, CancellationToken.None);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] AddProductInCartRequest request)
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

        [HttpPut("{id:guid}/change-quantity/{operation}")]
        public async Task<IActionResult> ChangeQuantity([FromRoute] Guid id, [FromRoute] string operation)
        {
            try
            {
                Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid).Value);


                var request = new ChangeQuantityRequest(id, userId, operation == "add" ? ECartOperation.Add : ECartOperation.Rem);

                var response = await _mediator.Send(request, CancellationToken.None);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            try
            {
                Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid).Value);
                var request = new RemoveProductRequest(id, userId);

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