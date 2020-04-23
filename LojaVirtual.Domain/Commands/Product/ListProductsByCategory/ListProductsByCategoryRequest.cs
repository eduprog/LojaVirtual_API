using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Commands.Product.ListProductsByCategory
{
    public class ListProductsByCategoryRequest : IRequest<ResponseGeneric>
    {
        public ListProductsByCategoryRequest(Guid idCategory)
        {
            IdCategory = idCategory;
        }

        public Guid IdCategory { get; private set; }
    }
}
