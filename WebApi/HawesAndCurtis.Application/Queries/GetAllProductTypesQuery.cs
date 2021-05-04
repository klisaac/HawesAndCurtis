using MediatR;
using System.Collections.Generic;
using HawesAndCurtis.Application.Responses;

namespace HawesAndCurtis.Application.Queries
{
    public class GetAllProductTypesQuery : IRequest<IEnumerable<ProductTypeResponse>>
    {
    }
}
