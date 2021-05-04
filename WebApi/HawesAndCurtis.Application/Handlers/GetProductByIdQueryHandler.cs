using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using HawesAndCurtis.Core.Specifications;
using HawesAndCurtis.Core.Repository;
using HawesAndCurtis.Application.Queries;
using HawesAndCurtis.Application.Responses;

namespace HawesAndCurtis.Application.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProductResponse>(await _productRepository.GetSingleAsync(new ProductSpecification(request.ProductId)));
        }
    }
}
