using System.Threading.Tasks;
using System.Collections.Generic;
using HawesAndCurtis.Core.Entities;
using HawesAndCurtis.Core.Pagination;
using HawesAndCurtis.Core.Repository.Base;

namespace HawesAndCurtis.Core.Repository
{
    public interface IProductRecommendationRepository : IBaseRepository<ProductRecommendation>
    {
        Task<IList<ProductType>> GetProductRecommendationTypes(int productId);
        Task<IPagedList<ProductRecommendation>> GetProductRecommendationsAsync(int productId, string productTypeName, int pageIndex, int pageSize);
    }
}
