using AutoMapper;
using Isa0091.Domain.Mvc.Filters.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyLocation.Core.Helper.PharmacyNearbyProduct;
using PharmacyLocation.Core;
using PharmacyLocation.Core.Provider.PharmacyNearbyProduct;
using PharmacyLocation.Core.Queries;
using PharmacyLocation.Handlers.Helpers;
using PharmacyLocation.Outputs;

namespace PharmacyLocation.Api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(
            IMediator mediator,
            IMapper mapper)
        {

            _mediator = mediator;
            _mapper = mapper;
        }
       

        
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedListOutput<ProductOutput>))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiExceptionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiExceptionResult))]
        [HttpGet()]
        public async Task<IActionResult> GetSearchProduct([FromQuery] string? NameContains, [FromQuery] int? Page, [FromQuery] int? ItemsPerPage)
        {

            GetSearchProduct getSearchProduct = new GetSearchProduct()
            {
                 ItemsPerPage = ItemsPerPage,
                 NameContains = NameContains,
                 Page = Page
            };

            PaginatedListOutput<Product> paginatedListProduct=   await _mediator.Send(getSearchProduct);

            PaginatedListOutput<ProductOutput> paginatedListProductOutput =
                _mapper.Map<PaginatedListOutput<ProductOutput>>(paginatedListProduct);

            return Ok(paginatedListProductOutput);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductOutput))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiExceptionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiExceptionResult))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] string id)
        {

            GetProductById getProductBy = new GetProductById()
            {
                ProductId= id
            };

            Product product = await _mediator.Send(getProductBy);

            ProductOutput productOutput = _mapper.Map<ProductOutput>(product);

            return Ok(productOutput);
        }
    }
}
