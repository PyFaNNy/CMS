namespace CMS.Domain.Entities.Abstract
{
    public abstract class VisibleEntity
    {
        public string Name { get; set; }
        public int VisualOrder { get; set; }
        public string Description { get; set; }

        protected VisibleEntity(string name, int visualOrder, string description)
        {
            Name = name;
            VisualOrder = visualOrder;
            Description = description;
        }

        protected VisibleEntity()
        {
        }
    }
}
