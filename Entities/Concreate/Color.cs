using Core.Entities;

namespace Entities.Concreate
{
    public class Color : IEntity
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
    }
}
