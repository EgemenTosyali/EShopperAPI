using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Domain.Entities
{
    public class InvoiceFile : File
    {
        public double Price { get; set; }
    }
}
