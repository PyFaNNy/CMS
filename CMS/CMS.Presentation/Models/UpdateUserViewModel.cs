using CMS.Application.Aggregates.User.Commands.ChangePassword;
using CMS.Application.Aggregates.User.Commands.ChangeRoles;
using CMS.Application.Aggregates.User.Queries.GetUser;

namespace СMS.Models
{
    public class UpdateUserViewModel
    {
        public User User { get; set; }
        public ChangePasswordCommand PasswordCommand { get; set; } = new ChangePasswordCommand();
        public ChangeRolesCommand RolesCommand { get; set; } = new ChangeRolesCommand();
    }
}
