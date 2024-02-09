using AutoMapper;
using Isa0091.Domain.Mvc.Filters.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyLocation.Core.Queries;
using PharmacyLocation.Core;
using PharmacyLocation.Outputs;
using PharmacyLocation.Core.Commands;
using PharmacyLocation.Handlers.Queries;
using System.Collections.Generic;

namespace PharmacyLocation.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(
            IMediator mediator,
            IMapper mapper)
        {

            _mediator = mediator;
            _mapper = mapper;
        }


        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FavoriteUserProductOutput))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiExceptionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiExceptionResult))]
        [HttpPost("{id}/favorite-products")]
        public async Task<IActionResult> CreateFavoriteProduct([FromRoute] string id, [FromBody] string productId)
        {

            CreateFavoriteUserProduct createFavoriteUserProduct = new CreateFavoriteUserProduct()
            {
                 IdUser = id,
                 ProductId = productId
            };

            FavoriteUserProduct favoriteUserProduct = await _mediator.Send(createFavoriteUserProduct);

            FavoriteUserProductOutput favoriteUserProductOutput =
                _mapper.Map<FavoriteUserProductOutput>(favoriteUserProduct);

            return Ok(favoriteUserProductOutput);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiExceptionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiExceptionResult))]
        [HttpDelete("{id}/favorite-products")]
        public async Task<IActionResult> DeleteFavoriteUserProduct([FromRoute] string id, [FromBody] string productId)
        {

            DeleteFavoriteUserProduct deleteFavoriteUserProduct = new DeleteFavoriteUserProduct()
            {
                IdUser = id,
                ProductId = productId
            };

            await _mediator.Send(deleteFavoriteUserProduct);

            return NoContent();
        }


        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductOutput>))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiExceptionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiExceptionResult))]
        [HttpGet("{id}/favorite-products")]
        public async Task<IActionResult> GetUserFavoriteProduct([FromRoute] string id)
        {

            GetUserFavoriteProduct deleteFavoriteUserProduct = new GetUserFavoriteProduct()
            {
                UserId = id
            };

            List<ProductOutput> productOutputs = new List<ProductOutput>();

            List<FavoriteUserProduct>  favoriteUserProducts  =await _mediator.Send(deleteFavoriteUserProduct);
            List<string> idsProducts = favoriteUserProducts.Select(p => p.ProductId).ToList();

            if(idsProducts.Any())
            {
                GetProductsByIds getProductsByIds = new GetProductsByIds()
                {
                    ProductsIds = idsProducts
                };

                List<Product> products = await _mediator.Send(getProductsByIds);

                productOutputs = _mapper.Map<List<ProductOutput>>(products);
            }

            return Ok(productOutputs);
        }

    }
}
