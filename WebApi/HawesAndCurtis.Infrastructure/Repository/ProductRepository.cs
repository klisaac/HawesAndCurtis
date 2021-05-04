    using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(HawesAndCurtisDataContext dbContext)
            : base(dbContext)
        {
        }

        public Task<IPagedList<Product>> GetProductsByTypeAsync(string productTypeName, string name, int pageIndex, int pageSize)
        {
            var query = Table.Include(p => p.ProductType).Include(p => p.ProductSpecifications).Where(p => p.ProductType.Name.ToLower() == productTypeName.ToLower() && p.Name.ToLower().Contains(string.IsNullOrWhiteSpace(name.ToLower()) ? string.Empty : name) && p.IsDeleted == false).OrderBy(p => p.Name);

            var products = new PagedList<Product>(query, new PagingArgs { PageIndex = pageIndex, PageSize = pageSize, PagingStrategy = PagingStrategy.WithCount }, null, null);

            return Task.FromResult<IPagedList<Product>>(products);
        }

        public Task<IPagedList<Product>> SearchProductsAsync(SearchArgs args)
        {
            var query = Table.Include(p => p.ProductType).Where(p => p.IsDeleted == false); ;

            var orderByList = new List<Tuple<SortingOption, Expression<Func<Product, object>>>>();

            if (args.SortingOptions != null)
            {
                foreach (var sortingOption in args.SortingOptions)
                {
                    switch (sortingOption.Field.ToLower())
                    {
                        case "id":
                            orderByList.Add(new Tuple<SortingOption, Expression<Func<Product, object>>>(sortingOption, p => p.ProductId));
                            break;
                        case "code":
                            orderByList.Add(new Tuple<SortingOption, Expression<Func<Product, object>>>(sortingOption, p => p.Code));
                            break;
                        case "name":
                            orderByList.Add(new Tuple<SortingOption, Expression<Func<Product, object>>>(sortingOption, p => p.Name));
                            break;
                        case "unitPrice":
                            orderByList.Add(new Tuple<SortingOption, Expression<Func<Product, object>>>(sortingOption, p => p.Price));
                            break;
                        case "description":
                            orderByList.Add(new Tuple<SortingOption, Expression<Func<Product, object>>>(sortingOption, p => p.Description));
                            break;
                        case "producttype.name":
                            orderByList.Add(new Tuple<SortingOption, Expression<Func<Product, object>>>(sortingOption, p => p.ProductType.Name));
                            break;
                    }
                }
            }

            if (orderByList.Count == 0)
            {
                orderByList.Add(new Tuple<SortingOption, Expression<Func<Product, object>>>(new SortingOption { Direction = SortingOption.SortingDirection.ASC }, p => p.ProductId));
            }

            //TODO: FilteringOption.Operator will be handled
            var filterList = new List<Tuple<FilteringOption, Expression<Func<Product, bool>>>>();

            if (args.FilteringOptions != null)
            {
                foreach (var filteringOption in args.FilteringOptions)
                {
                    switch (filteringOption.Field.ToLower())
                    {
                        case "id":
                            filterList.Add(new Tuple<FilteringOption, Expression<Func<Product, bool>>>(filteringOption, p => p.ProductId == Convert.ToInt32(filteringOption.Value)));
                            break;
                        case "code":
                            filterList.Add(new Tuple<FilteringOption, Expression<Func<Product, bool>>>(filteringOption, p => p.Code.Contains((string)filteringOption.Value)));
                            break;
                        case "name":
                            filterList.Add(new Tuple<FilteringOption, Expression<Func<Product, bool>>>(filteringOption, p => p.Name.Contains((string)filteringOption.Value)));
                            break;
                        case "unitPrice":
                            filterList.Add(new Tuple<FilteringOption, Expression<Func<Product, bool>>>(filteringOption, p => p.Price == Convert.ToDecimal(filteringOption.Value)));
                            break;
                        case "description":
                            filterList.Add(new Tuple<FilteringOption, Expression<Func<Product, bool>>>(filteringOption, p => p.Description.Contains(filteringOption.Value)));
                            break;
                        case "category.name":
                            filterList.Add(new Tuple<FilteringOption, Expression<Func<Product, bool>>>(filteringOption, p => p.ProductType.Name.Contains((string)filteringOption.Value)));
                            break;
                    }
                }
            }

            var productPagedList = new PagedList<Product>(query, new PagingArgs { PageIndex = args.PageIndex, PageSize = args.PageSize, PagingStrategy = args.PagingStrategy }, orderByList, filterList);

            return Task.FromResult<IPagedList<Product>>(productPagedList);
        }
        
    }
}
