using Evimden.CoreLayer.Abstract;

namespace Evimden.CoreLayer.Concrete
{
    public class BaseEntity : IEntity
    {
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
