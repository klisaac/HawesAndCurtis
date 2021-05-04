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
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IPagedList<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IPagedList<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IPagedList<ProductResponse>>(await _productRepository.GetAllAsync());
        }
    }
}
