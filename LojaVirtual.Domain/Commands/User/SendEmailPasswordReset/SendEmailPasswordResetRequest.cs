using Flunt.Validations;
using LojaVirtual.Domain.Commands.Base;
using MediatR;

namespace LojaVirtual.Domain.Commands.User.SendEmailPasswordReset
{
    public class SendEmailPasswordResetRequest : RequestBase, IRequest<ResponseGeneric>
    {
        public SendEmailPasswordResetRequest(string email)
        {
            Email = email;
        }

        public string Email { get; private set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
               .Requires()
               .IsNotNullOrEmpty(Email, "E-mail", "E-mail é obrigatório")
               .HasMaxLen(Email, 200, "E-mail", "E-mail deve conter no máximo 200 caracteres")
               .IsEmail(Email, "E-mail", "E-mail inválido")
           );
        }
    }
}
