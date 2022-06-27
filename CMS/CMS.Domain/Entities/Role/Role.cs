using CMS.Domain.Interfaces;

namespace CMS.Domain.Entities.Role
{
    public class Role : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<User.User> Users { get; set; }
    }
}
