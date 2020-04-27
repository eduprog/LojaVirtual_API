using LojaVirtual.Domain.Commands.Base;
using LojaVirtual.Domain.Extensions;
using LojaVirtual.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Commands.User.Authenticate
{
    public class AuthenticateUserHandler : HandlerBase, IRequestHandler<AuthenticateUserRequest, ResponseGeneric>
    {
        private readonly IUserRepository userRepository;

        public AuthenticateUserHandler(
            IUserRepository userRepository    
        )
        {
            this.userRepository = userRepository;
        }

        public async Task<ResponseGeneric> Handle(AuthenticateUserRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                AddNotifications(request.Notifications);
                return new ResponseGeneric(false, "Não foi possível entrar! Usuário inválido.", request.Notifications);
            }

            Entities.User userExists = this.userRepository.GetBy(x => x.Email == request.Email);

            if (userExists == null)
            {
                AddNotification("User", "Usuário inválido");
                return new ResponseGeneric(false, "Não foi possível entrar! Usuário inválido.", Notifications);
            }

            if (!request.Password.CompareHashBCrypt(userExists.Password))
            {
                AddNotification("User", "Usuário inválido");
                return new ResponseGeneric(false, "Não foi possível entrar! Usuário inválido.", Notifications);
            }

            var response = new ResponseGeneric(true, "Usuário autenticado com sucesso", userExists);

            return await Task.FromResult(response);
        }
    }
}
