using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using HawesAndCurtis.Core.Entities.Base;


namespace HawesAndCurtis.Core.Entities
{
    public class ProductType : AuditEntity
    {
        public int ProductTypeId { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
