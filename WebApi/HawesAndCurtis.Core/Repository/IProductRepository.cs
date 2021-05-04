using HawesAndCurtis.Core.Entities;
using HawesAndCurtis.Core.Pagination;
using HawesAndCurtis.Core.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HawesAndCurtis.Core.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IPagedList<Product>> GetProductsByTypeAsync(string productTypeName, string name, int pageIndex, int pageSize);
        Task<IPagedList<Product>> SearchProductsAsync(SearchArgs args);
    }
}
