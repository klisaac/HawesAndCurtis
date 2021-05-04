using System.Collections.Generic;
using MediatR;
using HawesAndCurtis.Core.Pagination;
using HawesAndCurtis.Application.Responses;

namespace HawesAndCurtis.Application.Queries
{
    public class GetProductsQuery: IRequest<IPagedList<ProductResponse>>
    {
        public string ProductTypeName { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }


        public GetProductsQuery(ProductParams productRequestParams)
        {
            ProductTypeName = !string.IsNullOrWhiteSpace(productRequestParams.ProductType) ? productRequestParams.ProductType : string.Empty;
            PageIndex = productRequestParams.PageIndex;
            PageSize = productRequestParams.PageSize;
            Name = productRequestParams.Search;

        }
    }
}
