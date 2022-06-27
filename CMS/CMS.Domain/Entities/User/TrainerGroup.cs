using CMS.Domain.Entities.Abstract;
using CMS.Domain.Interfaces;

namespace CMS.Domain.Entities.User
{
    public class TrainerGroup : VisibleEntity, IBaseEntity
    {
        public Guid Id { get; set; }

        public List<Trainer> Trainers { get; set; }

        public TrainerGroup(string name, int visualOrder, string description) : base(name, visualOrder, description)
        {
        }
    }
}
