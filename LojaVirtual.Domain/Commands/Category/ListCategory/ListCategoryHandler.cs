using LojaVirtual.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Commands.Category.ListCategory
{
    public class ListCategoryHandler : IRequestHandler<ListCategoryRequest, ResponseGeneric>
    {
        private readonly ICategoryRepository categoryRepository;

        public ListCategoryHandler(
            ICategoryRepository categoryRepository    
        )
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<ResponseGeneric> Handle(ListCategoryRequest request, CancellationToken cancellationToken)
        {
            // validar

            var list = this.categoryRepository.ListOrderBy(x => x.Title);

            var response = new ResponseGeneric(true, "Categorias listadas com sucesso", list);

            return await Task.FromResult(response);
        }
    }
}
