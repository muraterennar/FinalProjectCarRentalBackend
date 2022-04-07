using Core.Entities;

namespace Entities.Concreate
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string BrandModel { get; set; }
    }
}
