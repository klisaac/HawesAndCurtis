using MediatR;
using System.Collections.Generic;
using HawesAndCurtis.Core.Pagination;
using HawesAndCurtis.Application.Responses;

namespace HawesAndCurtis.Application.Queries
{
    public class GetProductRecommendationsQuery: IRequest<IEnumerable<ProductResponse>>
    {
        public int ProductId { get; set; }
        public int RecommendedProductTypeId { get; set; }
        public GetProductRecommendationsQuery(int productId, int recommendedProductTypeId)
        {
            ProductId = productId;
            RecommendedProductTypeId = recommendedProductTypeId;
        }
    }
}
