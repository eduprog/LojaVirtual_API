using LojaVirtual.Api.Controllers.Base;
using LojaVirtual.Api.Helpers.Authentication;
using LojaVirtual.Domain.Commands.User.Authenticate;
using LojaVirtual.Domain.Commands.User.Register;
using LojaVirtual.Domain.Commands.User.SendEmailPasswordReset;
using LojaVirtual.Domain.Interfaces.Transactions;
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
                    response.Data = GenerateToken.Generate(response, signingConfigurations, tokenConfigurations);
                    return await ResponseSaveAsync(response);
                }

                return ResponseGet(response);
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
                    response.Data = GenerateToken.Generate(response, signingConfigurations, tokenConfigurations);

                    return ResponseGet(response);
                }

                return ResponseGet(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("send-email-password-reset")]
        public async Task<IActionResult> SendEmailPasswordReset(
            [FromBody] SendEmailPasswordResetRequest request)
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);

                if (response.Success == true)
                {
                    return await ResponseSaveAsync(response);
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