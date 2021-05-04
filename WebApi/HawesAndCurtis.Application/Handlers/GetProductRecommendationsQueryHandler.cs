using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using AutoMapper;
using HawesAndCurtis.Core.Pagination;
using HawesAndCurtis.Core.Repository;
using HawesAndCurtis.Core.Specifications;
using HawesAndCurtis.Application.Queries;
using HawesAndCurtis.Application.Responses;

namespace HawesAndCurtis.Application.Handlers
{
    public class GetProductRecommendationsQueryHandler : IRequestHandler<GetProductRecommendationsQuery, IEnumerable<ProductResponse>>
    {
        private readonly IProductRecommendationRepository _productRecommenadtionRepository;
        private readonly IMapper _mapper;

        public GetProductRecommendationsQueryHandler(IProductRecommendationRepository productRecommenadtionRepository, IMapper mapper)
        {
            _productRecommenadtionRepository = productRecommenadtionRepository ?? throw new ArgumentNullException(nameof(productRecommenadtionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductResponse>> Handle(GetProductRecommendationsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ProductResponse>>(await _productRecommenadtionRepository.GetAsync(new ProductRecommendationSpecification(request.ProductId, request.RecommendedProductTypeId)));
            //return _mapper.Map<IEnumerable<ProductResponse>>(await _productRecommenadtionRepository.GetProductRecommendationsAsync(request.ProductId, request.ProductTypeName, request.PageIndex, request.PageSize));
        }
    }
}
