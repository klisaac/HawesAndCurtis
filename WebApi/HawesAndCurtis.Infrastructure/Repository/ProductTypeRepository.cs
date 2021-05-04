using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HawesAndCurtis.Core.Entities;
using HawesAndCurtis.Core.Pagination;
using HawesAndCurtis.Core.Repository;
using HawesAndCurtis.Infrastructure.Data;
using HawesAndCurtis.Infrastructure.Pagination;
using HawesAndCurtis.Infrastructure.Repository.Base;

namespace HawesAndCurtis.Infrastructure.Repository
{
    public class ProductTypeRepository : BaseRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(HawesAndCurtisDataContext dbContext)
            : base(dbContext)
        {
        }
    }
}
