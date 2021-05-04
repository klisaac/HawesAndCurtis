using System.Collections.Generic;
using HawesAndCurtis.Application.Models;

namespace HawesAndCurtis.Application.Responses
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string ImageFile { get; set; }
        public ProductTypeModel Category { get; set; }
        public IEnumerable<SpecificationModel> Specifications { get; set; }

    }
}
