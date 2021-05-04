using System.Collections.Generic;
using MediatR;
using HawesAndCurtis.Application.Responses;

namespace HawesAndCurtis.Application.Queries
{
    public class GetProductRecommendationTypesQuery: IRequest<IEnumerable<ProductTypeResponse>>
    {
        public int ProductId { get; set; }

        public GetProductRecommendationTypesQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
