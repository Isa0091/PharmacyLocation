using AutoMapper;
using Isa0091.Domain.Mvc.Filters.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyLocation.Core;
using PharmacyLocation.Core.Helper.PharmacyNearbyProduct;
using PharmacyLocation.Core.Provider.PharmacyNearbyProduct;
using PharmacyLocation.Core.Queries;
using PharmacyLocation.Outputs;
using System.Collections.Generic;

namespace PharmacyLocation.Api.Controllers
{
    [Route("api/pharmacy")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IPharmacyNearbyProductHelper _pharmacyNearbyProductHelper;

        public PharmacyController(
            IMediator mediator,
            IMapper mapper,
            IPharmacyNearbyProductHelper pharmacyNearbyProductHelper)
        {

            _mediator = mediator;
            _mapper = mapper;
            _pharmacyNearbyProductHelper = pharmacyNearbyProductHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PharmacyProductOutput>))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiExceptionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiExceptionResult))]
        [HttpGet("/products/{id}")]
        public async Task<IActionResult> GetSearchPharmacyProduct([FromRoute] string id, double latitude, double longitude, double? presicion)
        {
            GetSearchPharmacyProduct getSearchPharmacyProducts = new GetSearchPharmacyProduct()
            {
                ProductId = id
            };

            List<PharmacyProductOutput> pharmacyProductOutputs = new List<PharmacyProductOutput>();

            List<PharmacyProduct> pharmacyProducts = await _mediator.Send(getSearchPharmacyProducts);
            List<string> pharmaciesIds = pharmacyProducts.Select(z => z.IdPharmacy).ToList();

            if (pharmaciesIds.Any())
            {
                List<Pharmacy> pharmacies = await _mediator.Send(new GetPharmaciesByIds()
                {
                    PharmaciesIds = pharmaciesIds
                });

                List<PharmacyOutput> pharmacyOutputs = _mapper.Map<List<PharmacyOutput>>(pharmacies);

                List<PharmacyNearbyProductOutput> pharmacyNearbyProducts = await _pharmacyNearbyProductHelper.GetPharmacyNearbyProduct(new PharmacyNearbyProductInput()
                {
                    Pharmacies = pharmacyOutputs,
                    UserLocation = new LocationVo()
                    {
                        Latitude = latitude,
                        Longitude = longitude,
                        Presicion = presicion ?? 0
                    }
                });

                foreach (PharmacyNearbyProductOutput pharmacyNearbyProduct in pharmacyNearbyProducts)
                {
                    PharmacyProduct pharmacy = pharmacyProducts.First(z => z.IdPharmacy == pharmacyNearbyProduct.PharmacyOutput.Id);

                    PharmacyProductOutput pharmacyProductOutput
                        = _mapper.Map<PharmacyProductOutput>(pharmacyNearbyProduct);

                    pharmacyProductOutput.Stock = pharmacy.Stock;

                    pharmacyProductOutputs.Add(pharmacyProductOutput);
                }
            }

            return Ok(pharmacyProducts);
        }
    }
}
