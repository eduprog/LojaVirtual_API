using LojaVirtual.Api.Controllers.Base;
using LojaVirtual.Api.Helpers.Authentication;
using LojaVirtual.Domain.Commands.User.Authenticate;
using LojaVirtual.Domain.Commands.User.Register;
using LojaVirtual.Infra.Transactions;
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
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;

        public AuthController(
            IMediator mediator, 
            IUnitOfWork unitOfWork            
        ) : base(unitOfWork)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(
            [FromBody] RegisterUserRequest request,
            [FromServices] SigningConfigurations signingConfigurations,
            [FromServices] TokenConfigurations tokenConfigurations)           
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);

                if (response.Success == true)
                {
                    var token = GenerateToken.Generate(response, signingConfigurations, tokenConfigurations);

                    return await ResponseSaveAsync(token);
                }

                return await ResponseSaveAsync(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] AuthenticateUserRequest request,
            [FromServices] SigningConfigurations signingConfigurations,
            [FromServices] TokenConfigurations tokenConfigurations)
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);

                if (response.Success == true)
                {
                    var token = GenerateToken.Generate(response, signingConfigurations, tokenConfigurations);

                    return ResponseGet(token);
                }

                return ResponseGet(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}