﻿using LojaVirtual.Domain.Commands.Base;
using LojaVirtual.Domain.Extensions;
using LojaVirtual.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Commands.User.Register
{
    public class RequestUserHandler : HandlerBase, IRequestHandler<RegisterUserRequest, ResponseGeneric>
    {
        private readonly IUserRepository userRepository;

        public RequestUserHandler(
            IUserRepository userRepository    
        )
        {
            this.userRepository = userRepository;
        }

        public async Task<ResponseGeneric> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                AddNotifications(request.Notifications);
                return new ResponseGeneric(false, "Não foi possível registrar! Usuário inválido.", request.Notifications);
            }

            Entities.User userExists = this.userRepository.GetBy(x => x.Email == request.Email);
            
            if (userExists != null)
            {
                AddNotification("E-mail", "E-mail está em uso");
                return new ResponseGeneric(false, "Não foi possível registrar! Usuário inválido.", Notifications);
            }

            string passwordHashed = request.Password.HashBCrypt();
            Entities.User user = new Entities.User(request.Name, request.Email, passwordHashed);
            user = this.userRepository.Add(user);            

            var response = new ResponseGeneric(true, "Usuário registrado com sucesso", user);

            return await Task.FromResult(response);
        }
    }
}
