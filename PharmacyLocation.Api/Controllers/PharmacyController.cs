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
        /// Obtengo las farmacias con sus datos de distancia
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PharmacyLocationOutput>))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiExceptionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiExceptionResult))]
        [HttpGet()]
        public async Task<IActionResult> GetSearchPharmacy([FromQuery]double latitude, [FromQuery] double longitude, [FromQuery] double? presicion)
        {

            List<Pharmacy> pharmacies = await _mediator.Send(new GetPharmacies());

            List<PharmacyOutput> pharmacyOutputs = _mapper.Map<List<PharmacyOutput>>(pharmacies);


            List<PharmacyLocationOutput> pharmacyProductOutputs = new List<PharmacyLocationOutput>();

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

                PharmacyLocationOutput pharmacyProductOutput
                    = _mapper.Map<PharmacyLocationOutput>(pharmacyNearbyProduct);

                pharmacyProductOutputs.Add(pharmacyProductOutput);
            }

            return Ok(pharmacyProductOutputs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PharmacyLocationProductOutput>))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiExceptionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiExceptionResult))]
        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetSearchPharmacyProduct([FromRoute] string id, [FromQuery] double latitude, [FromQuery] double longitude, [FromQuery] double? presicion)
        {
            GetSearchPharmacyProduct getSearchPharmacyProducts = new GetSearchPharmacyProduct()
            {
                ProductId = id
            };

            List<PharmacyLocationProductOutput> pharmacyProductOutputs = new List<PharmacyLocationProductOutput>();

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

                    PharmacyLocationProductOutput pharmacyProductOutput
                        = _mapper.Map<PharmacyLocationProductOutput>(pharmacyNearbyProduct);

                    pharmacyProductOutput.Stock = pharmacy.Stock;

                    pharmacyProductOutputs.Add(pharmacyProductOutput);
                }
            }

            return Ok(pharmacyProductOutputs);
        }
    }
}
