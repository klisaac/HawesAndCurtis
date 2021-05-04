
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HawesAndCurtis.Core.Entities.Base;

namespace HawesAndCurtis.Core.Entities
{
    public class Product : AuditEntity
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal? Price { get; set; }
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<ProductRecommendation> ProductRecommendations { get; set; }
        public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; }


    }
}
