using LojaVirtual.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Entities
{
    public class User : EntityBase
    {
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
