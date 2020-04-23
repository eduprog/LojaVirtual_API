using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Domain.Commands;
using LojaVirtual.Infra.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Api.Controllers.Base
{
    public class BaseController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> ResponseSaveAsync(ResponseGeneric response)
        {
            if (response.Success)
            {
                await this.unitOfWork.SaveChanges();

                return Ok(response);
            }
            return BadRequest(response);
        }

        public async Task<IActionResult> ResponseAsync(ResponseGeneric response)
        {
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}