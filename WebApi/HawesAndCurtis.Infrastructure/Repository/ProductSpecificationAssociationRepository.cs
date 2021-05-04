using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using HawesAndCurtis.Core.Entities;
using HawesAndCurtis.Core.Repository;
using HawesAndCurtis.Infrastructure.Data;
using HawesAndCurtis.Infrastructure.Repository.Base;
using HawesAndCurtis.Core.Specifications;

namespace HawesAndCurtis.Infrastructure.Repository
{
    public class ProductSpecificationAssociationRepository : BaseRepository<Core.Entities.ProductSpecification>, IProductSpecificationAssociationRepository
    {
        public ProductSpecificationAssociationRepository(HawesAndCurtisDataContext dbContext)
            : base(dbContext)
        {
        }
    }
}
