using CMS.Domain.Interfaces;

namespace CMS.Domain.Entities.User
{
    public class Trainer : IBaseEntity
    {
        public Guid Id { get; set; }
        public int VisualOrder { get; set; }
        public Guid TrainerGroupId { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public TrainerGroup TrainerGroup { get; set; }
        public List<Course.Course> Courses { get; set; }

        public Trainer(Guid id, int visualOrder, Guid trainerGroupId, string description)
        {
            Id = id;
            VisualOrder = visualOrder;
            TrainerGroupId = trainerGroupId;
            Description = description;
        }
    }
}
