using LojaVirtual.Domain.Entities.Base;
using LojaVirtual.Domain.Enums;
using LojaVirtual.Domain.Extensions;
using System;

namespace LojaVirtual.Domain.Entities
{
    public class UserToken : EntityBase
    {
        public UserToken(User user, EUserTokenType type)
        {
            ExpirationDate = DateTime.Now.AddHours(3);
            Token = Guid.NewGuid().ToString().HashBCrypt();
            User = user;
            Active = true;
            AccessDate = null;
            Type = type;
        }

        public UserToken()
        {
        }

        public DateTime ExpirationDate { get; private set; }
        public string Token { get; private set; }
        public User User { get; private set; }
        public bool Active { get; private set; }
        public DateTime? AccessDate { get; private set; }
        public EUserTokenType Type { get; private set; }

        public void InactivateToken()
        {
            Active = false;
        }
    }
}
