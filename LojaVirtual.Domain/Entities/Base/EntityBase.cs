using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public Guid Id { get; private set; }
        public DateTime CreateDate { get; private set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }
    }
}
