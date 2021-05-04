using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using AutoMapper;
using HawesAndCurtis.Core.Repository;
using HawesAndCurtis.Core.Specifications;
using HawesAndCurtis.Application.Queries;
using HawesAndCurtis.Application.Responses;

namespace HawesAndCurtis.Application.Handlers
{
    public class GetProductRecommendationTypesQueryHandler : IRequestHandler<GetProductRecommendationTypesQuery, IEnumerable<ProductTypeResponse>>
    {
        private readonly IProductRecommendationRepository _productRecommendatioRepository;
        private readonly IMapper _mapper;
        public GetProductRecommendationTypesQueryHandler(IProductRecommendationRepository productRecommendatioRepository, IMapper mapper)
        {
            _productRecommendatioRepository = productRecommendatioRepository ?? throw new ArgumentNullException(nameof(productRecommendatioRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductTypeResponse>> Handle(GetProductRecommendationTypesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<ProductTypeResponse>>(await _productRecommendatioRepository.GetProductRecommendationTypes(request.ProductId));
        }
    }
}
