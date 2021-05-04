using MediatR;
using HawesAndCurtis.Application.Responses;

namespace HawesAndCurtis.Application.Queries
{
    public class GetProductByIdQuery: IRequest<ProductResponse>
    {
        public int ProductId { get; set; }

        public GetProductByIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
