using LojaVirtual.Domain.Entities.Base;

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

        public User GetUserWithoutPassword()
        {
            User clone = (User)this.MemberwiseClone();

            clone.Password = null;
            return clone;
        }
    }
}
