using Flunt.Validations;
using LojaVirtual.Domain.Commands.Base;
using MediatR;

namespace LojaVirtual.Domain.Commands.User.Authenticate
{
    public class AuthenticateUserRequest : RequestBase, IRequest<ResponseGeneric>
    {
        public AuthenticateUserRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
               .Requires()
               .IsNotNullOrEmpty(Email, "E-mail", "E-mail é obrigatório")
               .HasMaxLen(Email, 200, "E-mail", "E-mail deve conter no máximo 200 caracteres")
               .IsEmail(Email, "E-mail", "E-mail inválido")
               .IsNotNullOrEmpty(Password, "Password", "Senha é obrigatória")
               .HasMinLen(Password, 6, "Password", "Senha deve conter no mínimo 6 caracteres")
               .HasMaxLen(Password, 20, "Password", "Senha deve conter no máximo 20 caracteres")
           );
        }
    }
}
