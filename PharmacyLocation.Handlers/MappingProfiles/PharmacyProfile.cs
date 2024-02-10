using AutoMapper;
using PharmacyLocation.Core;
using PharmacyLocation.Core.Helper.PharmacyNearbyProduct;
using PharmacyLocation.Outputs;

namespace PharmacyLocation.Handlers.MappingProfiles
{
    public class PharmacyProfile : Profile
    {
        public PharmacyProfile()
        {
            CreateMap<PharmacyProduct, PharmacyLocationOutput>();

            CreateMap<PharmacyNearbyProductOutput, PharmacyLocationOutput>();

            CreateMap<PharmacyNearbyProductOutput, PharmacyLocationProductOutput>()
              .ForMember(x => x.Stock, opt => opt.Ignore());

            CreateMap<Pharmacy, PharmacyOutput>();
        }
    }
}