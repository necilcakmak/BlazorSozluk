using BlazorSozluk.Api.Application.Interfaces.Repositories;
using BlazorSozluk.Common.Infrastructure.Exceptions;
using MediatR;

namespace BlazorSozluk.Api.Application.Features.Commands.User.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly IUserRepository userRepository;
        private readonly IEmailComfirmationRepository emailComfirmationRepository;

        public ConfirmEmailCommandHandler(IUserRepository userRepository, IEmailComfirmationRepository emailComfirmationRepository)
        {
            this.userRepository = userRepository;
            this.emailComfirmationRepository = emailComfirmationRepository;
        }

        public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var confirmation = await emailComfirmationRepository.GetByIdAsync(request.ConfirmationId);
            if (confirmation is null)
                throw new DatabaseValidationException("Confirmation not found!");

            var dbUser = await userRepository.GetSingleAsync(i => i.Email == confirmation.NewEmailAdress);
            if (dbUser is null)
                throw new DatabaseValidationException("User not found with this email!");
            if (dbUser.EmailConfirmed)
                throw new DatabaseValidationException("Email address is already confirmed!");

            dbUser.EmailConfirmed = true;
            await userRepository.UpdateAsync(dbUser);
            return true;
        }
    }
}
