using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LojaVirtual.Domain.Commands.Category.ListCategory;
using LojaVirtual.Domain.Commands.Product.ListProductsByCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(
            IMediator mediator
        )
        {
            this._mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var request = new ListCategoryRequest();
                var response = await _mediator.Send(request, CancellationToken.None);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("{idCategory:guid}/products")]
        public async Task<IActionResult> GetProducts(Guid idCategory)
        {
            try
            {
                var request = new ListProductsByCategoryRequest(idCategory);
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