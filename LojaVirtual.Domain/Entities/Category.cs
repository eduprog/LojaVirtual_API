using LojaVirtual.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category(string title, string icon)
        {
            Title = title;
            Icon = icon;
            UserCreate = null;
        }

        public string Title { get; private set; }
        public string Icon { get; private set; }
        public User UserCreate { get; private set; }
    }
}
