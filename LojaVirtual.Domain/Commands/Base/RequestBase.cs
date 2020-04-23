using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Commands.Base
{
    public abstract class RequestBase : Notifiable, IValidatable
    {
        public abstract void Validate();
    }
}
