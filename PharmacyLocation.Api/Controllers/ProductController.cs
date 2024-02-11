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
using System.Collections.Generic;

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
        public async Task<IActionResult> GetSearchProduct([FromQuery] string? NameContains, [FromQuery] List<string> categoryIds , [FromQuery] int? Page, [FromQuery] int? ItemsPerPage)
        {

            GetSearchProduct getSearchProduct = new GetSearchProduct()
            {
                 ItemsPerPage = ItemsPerPage,
                 NameContains = NameContains,
                 CategoryIds = categoryIds,
                 Page = Page
            };

            PaginatedListOutput<Product> paginatedListProduct=   await _mediator.Send(getSearchProduct);

            PaginatedListOutput<ProductOutput> paginatedListProductOutput =
                _mapper.Map<PaginatedListOutput<ProductOutput>>(paginatedListProduct);


            List<CategoryOutput> categoryOutputs = await GetCategoriesProduct(paginatedListProduct.Items);


            foreach (ProductOutput productOutput in paginatedListProductOutput.Items)
            {
                Product product = paginatedListProduct.Items.First(x => x.Id == productOutput.Id);

                List<CategoryOutput> categoriesProduct = categoryOutputs.Where(z=> product.CategoryProducts.Any(x=> x.CategoryId == z.Id)).ToList() ;
                productOutput.CategoryOutputs = categoriesProduct;
            }

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

            List<CategoryOutput> categoryOutputs = await GetCategoriesProduct(new List<Product> { product });
             productOutput.CategoryOutputs = categoryOutputs;

            return Ok(productOutput);
        }


        #region Metodos provados

        private async Task AddCategoriesProducOutput()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        private async Task<List<CategoryOutput>> GetCategoriesProduct(List<Product> products)
        {
            List<CategoryProduct> categoryProducts = products.SelectMany(x => x.CategoryProducts).ToList();
            List<string> categoriesIds = categoryProducts.Select(x => x.CategoryId).ToList();

            GetCategoriesByIds getCategoriesByIds = new GetCategoriesByIds()
            {
                CategoriesIds = categoriesIds
            };

            List<Category> categories = await _mediator.Send(getCategoriesByIds);

            List<CategoryOutput> categoryOutput = _mapper.Map<List<CategoryOutput>>(categories);

            return categoryOutput;
        }

        #endregion
    }
}
