using Flunt.Validations;
using LojaVirtual.Domain.Commands.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Commands.User.Register
{
    public class RegisterUserRequest : RequestBase, IRequest<ResponseGeneric>
    {
        public RegisterUserRequest(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
               .Requires()
               .IsNotNullOrEmpty(Name, "Name", "Nome é obrigatório")               
               .HasMaxLen(Name, 200, "Name", "Nome deve conter no máximo 200 caracteres")
               .IsNotNullOrEmpty(Email, "E-mail", "E-mail é obrigatório")
               .HasMaxLen(Email, 200, "E-mail", "E-mail deve conter no máximo 200 caracteres")
               .IsEmail(Email, "E-mail", "E-mail inválido")
               .IsNotNullOrEmpty(Password, "Password", "Senha é obrigatória")
               .HasMinLen(Password, 6, "Password", "Senha deve conter no mínimo 6 caracteres")
               .HasMaxLen(Password, 20, "E-mail", "Senha deve conter no máximo 20 caracteres")
           );
        }
    }
}
