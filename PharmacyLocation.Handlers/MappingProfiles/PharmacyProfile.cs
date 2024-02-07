using AutoMapper;
using PharmacyLocation.Core;
using PharmacyLocation.Core.Helper.PharmacyNearbyProduct;
using PharmacyLocation.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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