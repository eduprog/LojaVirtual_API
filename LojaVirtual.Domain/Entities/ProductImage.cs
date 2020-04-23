using LojaVirtual.Domain.Entities.Base;

namespace LojaVirtual.Domain.Entities
{
    public class ProductImage : EntityBase
    {
        public ProductImage(string image)
        {
            Image = image;
            Product = null;
            UserCreate = null;
        }

        public string Image { get; private set; }
        public Product Product { get; private set; }
        public User UserCreate { get; private set; }
    }
}
