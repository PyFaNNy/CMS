using MediatR;

namespace CMS.Application.Aggregates.User.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
