using HawesAndCurtis.Core.Entities;
using HawesAndCurtis.Core.Specifications.Base;

namespace HawesAndCurtis.Core.Specifications
{
    public class ProductSpecificationSpecification : BaseSpecification<ProductSpecification>
    {
        public ProductSpecificationSpecification(int productId)
            : base(s => s..ProductId == productId)
        {
            AddInclude(s => s.Product);
            AddInclude(s => s.Specification);
        }

        public ProductSpecificationSpecification() : base(null)
        {
            AddInclude(s => s.Product);
            AddInclude(s => s.Specification);
        }
    }
}
