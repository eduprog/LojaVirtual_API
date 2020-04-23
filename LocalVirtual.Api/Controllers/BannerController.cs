using LojaVirtual.Domain.Commands.Banner.ListBannerByLocal;
using LojaVirtual.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BannerController(
            IMediator mediator    
        )
        {
            this._mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("{local:int}")]
        public async Task<IActionResult> GetByLocal(EBannerLocal local)
        {
            try
            {
                var request = new ListBannerByLocalRequest(local);
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