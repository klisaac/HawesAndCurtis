using HawesAndCurtis.Core.Entities;
using HawesAndCurtis.Core.Specifications.Base;

namespace HawesAndCurtis.Core.Specifications
{
    public class ProductRecommendationSpecification : BaseSpecification<ProductRecommendation>
    {
        public ProductRecommendationSpecification() : base(null)
        {
            AddInclude(r => r.Product.ProductType);
        }

        public ProductRecommendationSpecification(int productId)
            : base(r => r.Product.ProductId == productId)
        {
            AddInclude(r => r.RecommendedProduct.ProductType);
            AddInclude(r => r.RecommendedProduct.ProductSpecifications);
            OrderBy = r => (r.RecommendedProduct.Name);
        }
        public ProductRecommendationSpecification(int productId, int productTypeName)
            : base(r => r.Product.ProductId == productId && r.RecommendedProduct.ProductTypeId == productTypeName)
        {
            AddInclude(r => r.RecommendedProduct.ProductType);
            AddInclude(r => r.RecommendedProduct.ProductSpecifications);
            OrderBy = r => (r.RecommendedProduct.Name);
        }
    }
}
