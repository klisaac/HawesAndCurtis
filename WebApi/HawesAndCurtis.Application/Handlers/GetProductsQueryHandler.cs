using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using AutoMapper;
using HawesAndCurtis.Core.Repository;
using HawesAndCurtis.Core.Specifications;
using HawesAndCurtis.Core.Pagination;
using HawesAndCurtis.Application.Queries;
using HawesAndCurtis.Application.Responses;

namespace HawesAndCurtis.Application.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IPagedList<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IPagedList<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IPagedList<ProductResponse>>(await _productRepository.GetProductsByTypeAsync(request.ProductTypeName, string.IsNullOrWhiteSpace(request.Name) ? string.Empty: request.Name, request.PageIndex, request.PageSize));
        }
    }
}
