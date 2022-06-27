using CMS.Domain.Interfaces;

namespace CMS.Domain.Entities.User
{
    public class User : IBaseEntity, IRemovedAt
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public byte[]? Photo { get; set; }

        public List<Role.Role> Roles { get; set; }
        public Trainer Trainer { get; set; }
    }
}
