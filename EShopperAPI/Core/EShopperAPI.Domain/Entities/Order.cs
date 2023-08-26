using EShopperAPI.Domain.Entities.Common;

namespace EShopperAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid customerId { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public ICollection<Product> Products { get; set; }
        public Customer Customer { get; set; }
    }
}
