using AutoMapper;
using PharmacyLocation.Core;
using PharmacyLocation.Core.Helper.PharmacyNearbyProduct;
using PharmacyLocation.Outputs;
using System.Globalization;

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

            CreateMap<PharmacySchedule, PharmacyScheduleOutput>()
                 .ForMember(x => x.Day, opt => opt.MapFrom(o => o.Day.GetDisplayName()))
                 .ForMember(dest => dest.OpeningTime, opt => opt.MapFrom(src => src.OpeningTime.ToString()))
                 .ForMember(dest => dest.ClosingTime, opt => opt.MapFrom(src => src.ClosingTime.ToString()));
        }
    }
}