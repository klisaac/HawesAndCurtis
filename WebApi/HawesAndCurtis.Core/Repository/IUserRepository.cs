using System.Threading.Tasks;
using HawesAndCurtis.Core.Entities;
using HawesAndCurtis.Core.Repository.Base;
using HawesAndCurtis.Core.Specifications.Base;

namespace HawesAndCurtis.Core.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
