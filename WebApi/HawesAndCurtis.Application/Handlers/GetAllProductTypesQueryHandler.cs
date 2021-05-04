using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using AutoMapper;
using HawesAndCurtis.Core.Repository;
using HawesAndCurtis.Core.Pagination;
using HawesAndCurtis.Application.Queries;
using HawesAndCurtis.Application.Responses;

namespace HawesAndCurtis.Application.Handlers
{
    public class GetAllProductTypesQueryHandler : IRequestHandler<GetAllProductTypesQuery, IEnumerable<ProductTypeResponse>>
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IMapper _mapper;

        public GetAllProductTypesQueryHandler(IProductTypeRepository productTypeRepository, IMapper mapper)
        {
            _productTypeRepository = productTypeRepository ?? throw new ArgumentNullException(nameof(productTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductTypeResponse>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ProductTypeResponse>>(await _productTypeRepository.GetAllAsync());
        }
    }
}
