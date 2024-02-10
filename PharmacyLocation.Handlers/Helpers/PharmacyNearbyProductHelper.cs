using ManagerEasyTransportTimeMapbox.Abstract;
using ManagerEasyTransportTimeMapbox.Data;
using ManagerEasyTransportTimeMapbox.Dto.Input;
using ManagerEasyTransportTimeMapbox.Dto.Output;
using PharmacyLocation.Core;
using PharmacyLocation.Core.Helper.PharmacyNearbyProduct;
using PharmacyLocation.Core.Provider.PharmacyNearbyProduct;
using PharmacyLocation.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Handlers.Helpers
{
    public class PharmacyNearbyProductHelper : IPharmacyNearbyProductHelper
    {
        public IManagerEasyTransportTimeMapboxProvider _managerEasyTransportTimeMapboxProvider;

        public PharmacyNearbyProductHelper(
            IManagerEasyTransportTimeMapboxProvider managerEasyTransportTimeMapboxProvider)
        {
            _managerEasyTransportTimeMapboxProvider = managerEasyTransportTimeMapboxProvider;
        }

        public async Task<List<PharmacyNearbyProductOutput>> GetPharmacyNearbyProduct(PharmacyNearbyProductInput pharmacyNearbyProductInput)
        {
            List<PharmacyNearbyProductOutput> pharmacyNearbyProducts = new List<PharmacyNearbyProductOutput>();


            foreach (PharmacyOutput pharmacy in pharmacyNearbyProductInput.Pharmacies)
            {
                TransportTimeOutputDto transportTimeOutputDriving =
              await _managerEasyTransportTimeMapboxProvider.CalculteTransportTime(new TransportTimeInputDto()
              {

                  DestinationLocation = new LocationInputDto()
                  {
                      Latitude = pharmacy.Location.Latitude,
                      Longitude = pharmacy.Location.Longitude
                  },
                  OriginLocation = new LocationInputDto()
                  {
                      Latitude = pharmacyNearbyProductInput.UserLocation.Latitude,
                      Longitude = pharmacyNearbyProductInput.UserLocation.Longitude
                  },
                  TransportType = TransportType.Driving
              });

                TransportTimeOutputDto transportTimeOutputWalking =
              await _managerEasyTransportTimeMapboxProvider.CalculteTransportTime(new TransportTimeInputDto()
              {

                  DestinationLocation = new LocationInputDto()
                  {
                      Latitude = pharmacy.Location.Latitude,
                      Longitude = pharmacy.Location.Longitude
                  },
                  OriginLocation = new LocationInputDto()
                  {
                      Latitude = pharmacyNearbyProductInput.UserLocation.Latitude,
                      Longitude = pharmacyNearbyProductInput.UserLocation.Longitude
                  },
                  TransportType = TransportType.Walking
              });

                TransportTimeOutputDto transportTimeOutputDrivingTraffic=
            await _managerEasyTransportTimeMapboxProvider.CalculteTransportTime(new TransportTimeInputDto()
            {

                DestinationLocation = new LocationInputDto()
                {
                    Latitude = pharmacy.Location.Latitude,
                    Longitude = pharmacy.Location.Longitude
                },
                OriginLocation = new LocationInputDto()
                {
                    Latitude = pharmacyNearbyProductInput.UserLocation.Latitude,
                    Longitude = pharmacyNearbyProductInput.UserLocation.Longitude
                },
                TransportType = TransportType.DrivingWithTraffic
            });

                PharmacyNearbyProductOutput pharmacyNearbyProduct = new PharmacyNearbyProductOutput()
                {
                    PharmacyOutput = pharmacy,
                    DistanceInMetersDriving = transportTimeOutputDriving.DistanceInMeters,
                    EstimatedTravelTimeDriving = transportTimeOutputDriving.TravelTime.TimeSpanToFriendlyString(),
                    DistanceInMetersWalking = transportTimeOutputWalking.DistanceInMeters,
                    EstimatedTravelTimeWalking = transportTimeOutputWalking.TravelTime.TimeSpanToFriendlyString(),
                    DistanceInMetersDrivingTraffic = transportTimeOutputDrivingTraffic.DistanceInMeters,
                    EstimatedTravelTimeDrivingTraffic = transportTimeOutputDrivingTraffic.TravelTime.TimeSpanToFriendlyString()
                };

                pharmacyNearbyProducts.Add(pharmacyNearbyProduct);
            }


            return pharmacyNearbyProducts;
        }
    }
}
