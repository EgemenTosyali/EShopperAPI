using EShopperAPI.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

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
