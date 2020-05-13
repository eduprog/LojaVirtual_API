using Flunt.Notifications;
using System;

namespace LojaVirtual.Domain.Entities.Base
{
    public abstract class EntityBase : Notifiable
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
