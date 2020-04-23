using LojaVirtual.Domain.Interfaces.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Commands.Product.ListProductsByCategory
{
    public class ListProductsByCategoryHandler : IRequestHandler<ListProductsByCategoryRequest, ResponseGeneric>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductRepository productRepository;

        public ListProductsByCategoryHandler(
            ICategoryRepository categoryRepository,
            IProductRepository productRepository
        )
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }

        public async Task<ResponseGeneric> Handle(ListProductsByCategoryRequest request, CancellationToken cancellationToken)
        {
            // validar id categoria

            Entities.Category category = this.categoryRepository.GetBy(x => x.Id == request.IdCategory);

            if (category == null)
            {
                // validar categoria não encontrada
                return null;
            }

            //var list = this.productRepository.Test(request.IdCategory);
            var list = this.productRepository.ListAndOrderBy(x => x.Category.Id == request.IdCategory, x => x.Title, true, x => x.Images, x => x.Sizes);

            var response = new ResponseGeneric(true, $"Produtos da categoria \'{category.Title}\' listados com sucesso", list);

            return await Task.FromResult(response);
        }
    }
}
