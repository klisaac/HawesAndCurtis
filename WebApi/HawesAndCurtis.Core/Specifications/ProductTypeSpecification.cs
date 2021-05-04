using HawesAndCurtis.Core.Entities;
using HawesAndCurtis.Core.Specifications.Base;

namespace HawesAndCurtis.Core.Specifications
{
    public class ProductTypeSpecification : BaseSpecification<ProductType>
    {
        public ProductTypeSpecification() : base(null)
        {
        }
        public ProductTypeSpecification(string name)
            : base(c => c.Name == name)
        {
        }

        public ProductTypeSpecification(int productTypeId)
            : base(c => c.ProductTypeId == productTypeId)
        {
        }
    }
}
