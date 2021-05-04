using System;
using System.Linq.Expressions;
using HawesAndCurtis.Core.Entities;
using HawesAndCurtis.Core.Specifications.Base;

namespace HawesAndCurtis.Core.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification() : base(null)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductSpecifications);
        }

        public ProductSpecification(int productId) : base(p => p.ProductId == productId)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductSpecifications);
        }

        public ProductSpecification(string categoryId) : base(p => p.ProductTypeId == Convert.ToInt32(categoryId))
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductSpecifications);
        }

        public ProductSpecification(string productCode, string productName) : base(null)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductSpecifications);
            Expression<Func<Product, bool>> productIdExpression = p => !string.IsNullOrEmpty(productCode) ? p.Code.Contains(productCode) : true;
            Expression<Func<Product, bool>> productNameExpression = p => !string.IsNullOrEmpty(productName) ? p.Name.ToLower().Contains(productName.ToLower()) : true;
            Criteria = productIdExpression.And(productNameExpression);
        }
    }
}
