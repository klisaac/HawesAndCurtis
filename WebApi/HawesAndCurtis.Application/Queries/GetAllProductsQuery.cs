using MediatR;
using HawesAndCurtis.Core.Pagination;
using HawesAndCurtis.Application.Responses;

namespace HawesAndCurtis.Application.Queries
{
    public class GetAllProductsQuery : IRequest<IPagedList<ProductResponse>>
    {
    }
}
