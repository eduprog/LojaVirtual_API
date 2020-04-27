using LojaVirtual.Domain.Entities.Base;

namespace LojaVirtual.Domain.Entities
{
    public class Place : EntityBase
    {
        public string Title { get; private set; }
        public string Telephone { get; private set; }
        public double? Latitude { get; private set; }
        public double? Longitude { get; private set; }
        public string Image { get; private set; }
        public string Address { get; private set; }
        public bool VisibleOnApp { get; set; }
    }
}
