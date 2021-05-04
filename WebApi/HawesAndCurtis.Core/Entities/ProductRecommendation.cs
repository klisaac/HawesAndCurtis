using HawesAndCurtis.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace HawesAndCurtis.Core.Entities
{
    public class ProductRecommendation : AuditEntity
    {
        public int ProductRecommendationId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int RecommendedProductId { get; set; }
        public virtual Product RecommendedProduct { get; set; }
    }
}
