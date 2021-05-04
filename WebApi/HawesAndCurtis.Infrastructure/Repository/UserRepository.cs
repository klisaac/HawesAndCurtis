using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HawesAndCurtis.Core.Entities;
using HawesAndCurtis.Core.Repository;
using HawesAndCurtis.Core.Specifications.Base;
using HawesAndCurtis.Infrastructure.Data;
using HawesAndCurtis.Infrastructure.Repository.Base;

namespace HawesAndCurtis.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(HawesAndCurtisDataContext AspNet5Context)
            : base(AspNet5Context)
        {
        }
    }
}
