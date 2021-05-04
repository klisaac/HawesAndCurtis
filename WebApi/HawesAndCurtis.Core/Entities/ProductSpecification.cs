using HawesAndCurtis.Core.Entities.Base;

namespace HawesAndCurtis.Core.Entities
{
    public class ProductSpecification : AuditEntity
    {
        public int ProductSpecificationId { get; set;}
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string Specification { get; set; }
    }
}
