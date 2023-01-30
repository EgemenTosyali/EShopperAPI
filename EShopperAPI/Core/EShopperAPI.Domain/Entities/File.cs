using EShopperAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Domain.Entities
{
    public class File : BaseEntity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Storage { get; set; }
        [NotMapped]
        public override DateTime updateDate { get => base.updateDate; set => base.updateDate = value; } 
    }
}
