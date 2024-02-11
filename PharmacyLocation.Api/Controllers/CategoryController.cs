using AutoMapper;
using Isa0091.Domain.Mvc.Filters.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyLocation.Core.Queries;
using PharmacyLocation.Core;
using PharmacyLocation.Outputs;

namespace PharmacyLocation.Api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryController(
            IMediator mediator,
            IMapper mapper)
        {

            _mediator = mediator;
            _mapper = mapper;
        }


        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedListOutput<CategoryOutput>))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiExceptionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiExceptionResult))]
        [HttpGet()]
        public async Task<IActionResult> GetSearchCategories([FromQuery] string? NameContains, [FromQuery] int? Page, [FromQuery] int? ItemsPerPage)
        {

            GetSearchCategories getSearchCategories = new GetSearchCategories()
            {
                ItemsPerPage = ItemsPerPage,
                NameContains = NameContains,
                Page = Page
            };

            PaginatedListOutput<Category> paginatedListCategory = await _mediator.Send(getSearchCategories);

            PaginatedListOutput<CategoryOutput> paginatedListCategoriesOutput =
                _mapper.Map<PaginatedListOutput<CategoryOutput>>(paginatedListCategory);

            return Ok(paginatedListCategoriesOutput);
        }
    }
}
