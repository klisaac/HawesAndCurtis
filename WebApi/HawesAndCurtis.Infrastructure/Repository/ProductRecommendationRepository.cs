using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HawesAndCurtis.Core.Entities;
using HawesAndCurtis.Core.Pagination;
using HawesAndCurtis.Core.Repository;
using HawesAndCurtis.Infrastructure.Data;
using HawesAndCurtis.Infrastructure.Pagination;
using HawesAndCurtis.Infrastructure.Repository.Base;

namespace HawesAndCurtis.Infrastructure.Repository
{
    public class ProductRecommendationRepository : BaseRepository<ProductRecommendation>, IProductRecommendationRepository
    {
        public ProductRecommendationRepository(HawesAndCurtisDataContext dbContext)
            : base(dbContext)
        {
        }

        public Task<IList<ProductType>> GetProductRecommendationTypes(int productId)
        {
            var query = Table.Include(r => r.RecommendedProduct.ProductType).Where(r => r.ProductId == productId && r.IsDeleted == false).OrderBy(r => r.RecommendedProduct.ProductType.Name).Select(c => c.RecommendedProduct.ProductType).Distinct();

            return Task.FromResult<IList<ProductType>>(query.ToList());
        }

        public Task<IPagedList<ProductRecommendation>> GetProductRecommendationsAsync(int productId, string productTypeName, int pageIndex, int pageSize)
        {
            var query = Table.Include(r => r.RecommendedProduct.ProductType).Where(r => r.ProductId == productId && r.RecommendedProduct.ProductType.Name.ToLower() == productTypeName.ToLower() && r.IsDeleted == false).OrderBy(r => r.RecommendedProduct.Name);

            var productRecommmendationPagedList = new PagedList<ProductRecommendation>(query, new PagingArgs { PageIndex = pageIndex, PageSize = pageSize, PagingStrategy = PagingStrategy.WithCount }, null, null);

            return Task.FromResult<IPagedList<ProductRecommendation>>(productRecommmendationPagedList);
        }

    }
}
