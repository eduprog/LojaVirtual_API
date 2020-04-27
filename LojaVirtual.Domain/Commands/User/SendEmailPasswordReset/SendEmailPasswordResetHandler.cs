using LojaVirtual.Domain.Commands.Base;
using LojaVirtual.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Commands.User.SendEmailPasswordReset
{
    public class SendEmailPasswordResetHandler : HandlerBase, IRequestHandler<SendEmailPasswordResetRequest, ResponseGeneric>
    {
        private readonly IUserRepository userRepository;
        private readonly IUserTokenRepository userTokenRepository;

        public SendEmailPasswordResetHandler(
            IUserRepository userRepository,
            IUserTokenRepository userTokenRepository
        )
        {
            this.userRepository = userRepository;
            this.userTokenRepository = userTokenRepository;
        }

        public async Task<ResponseGeneric> Handle(SendEmailPasswordResetRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                AddNotifications(request.Notifications);
                return new ResponseGeneric(false, "Não foi possível resetar a senha! Usuário inválido.", request.Notifications);
            }

            Entities.User userExists = this.userRepository.GetBy(x => x.Email == request.Email);

            if (userExists == null)
            {
                AddNotification("User", "Usuário inválido");
                return new ResponseGeneric(false, "Não foi possível resetar a senha! Usuário inválido.", Notifications);
            }

            //procurar um token do usuário, activo e do tipo reset;
            //se tiver, desativa ele e cria um novo
            var tokenExist = this.userTokenRepository
                .GetBy(x => x.Active == true && x.User.Id == userExists.Id && x.Type == Enums.EUserTokenType.ResetPassword);

            if (tokenExist != null)
            {
                tokenExist.InactivateToken();
                this.userTokenRepository.Update(tokenExist);
            }

            Entities.UserToken userToken = new Entities.UserToken(userExists, Enums.EUserTokenType.ResetPassword);
            this.userTokenRepository.Add(userToken);

            var response = new ResponseGeneric(true, "Você irá receber um e-mail para redefinir a senha de acesso.", null);

            return await Task.FromResult(response);
        }
    }
}
