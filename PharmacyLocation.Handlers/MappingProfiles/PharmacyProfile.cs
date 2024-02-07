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
            CreateMap<PharmacyProduct, PharmacyProductOutput>();

            CreateMap<PharmacyNearbyProductOutput, PharmacyProductOutput>()
               .ForMember(x => x.Stock, opt => opt.Ignore());
        }
    }
}