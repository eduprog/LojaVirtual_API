using LojaVirtual.Domain.Commands;
using LojaVirtual.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LojaVirtual.Api.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        protected BaseController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected async Task<IActionResult> ResponseSaveAsync(object response)
        {
            await this.unitOfWork.SaveChanges();

            return Ok(response);
        }

        protected IActionResult ResponseGet(object response)
        {
            return Ok(response);
        }
    }
}