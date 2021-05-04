using MediatR;
using HawesAndCurtis.Core.Pagination;
using HawesAndCurtis.Application.Responses;

namespace HawesAndCurtis.Application.Queries
{
    public class SearchProductsQuery: IRequest<IPagedList<ProductResponse>>
    {
        public SearchArgs Args { get; set; }
        public SearchProductsQuery(SearchArgs args)
        {
            Args = args;
        }
    }
}
