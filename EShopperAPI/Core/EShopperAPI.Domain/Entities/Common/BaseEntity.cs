namespace EShopperAPI.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime createDate { get; set; }
        virtual public DateTime updateDate { get; set; }
    }
}
