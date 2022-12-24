using EShopperAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
