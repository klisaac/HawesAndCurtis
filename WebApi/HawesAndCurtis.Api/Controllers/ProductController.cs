using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MediatR;
using HawesAndCurtis.Core.Logging;
using HawesAndCurtis.Core.Pagination;
using HawesAndCurtis.Application.Queries;
using HawesAndCurtis.Application.Responses;

namespace HawesAndCurtis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Role.Admin)]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHawesAndCurtisLogger<ProductController> _logger;

        public ProductController(IMediator mediator, IHawesAndCurtisLogger<ProductController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("getProducts")]
        [ProducesResponseType(typeof(IPagedList<ProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IPagedList<ProductResponse>>> GetProducts([FromQuery] ProductParams productParams)
        {
            return Ok(await _mediator.Send(new GetProductsQuery(productParams)));
        }

        [HttpGet("getProductRecommendationTypes/{productId:int}")]
        [ProducesResponseType(typeof(IEnumerable<ProductTypeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductTypeResponse>>> GetProductRecommendationTypes(int productId)
        {
            return Ok(await _mediator.Send(new GetProductRecommendationTypesQuery(productId)));
        }

        [HttpGet("getProductRecommendations/{productId:int}/{recommendedProductTypeId:int}")]
        [ProducesResponseType(typeof(IEnumerable<ProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProductRecommendationsByType(int productId, int recommendedProductTypeId)
        {
            return Ok(await _mediator.Send(new GetProductRecommendationsQuery(productId, recommendedProductTypeId)));
        }

        [HttpGet("getById/{productId:int}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductResponse>> GetProductById(int productId)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery(productId)));
        }

        [HttpPost("search")]
        [ProducesResponseType(typeof(IPagedList<ProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IPagedList<ProductResponse>>> Search([FromBody] PageSearchArgs searchArgs)
        {
            return Ok(await _mediator.Send(new SearchProductsQuery(searchArgs.Args)));
        }
    }
}
