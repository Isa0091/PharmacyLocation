using AutoMapper;
using PharmacyLocation.Core;
using PharmacyLocation.Core.Helper.PharmacyNearbyProduct;
using PharmacyLocation.Outputs;

namespace PharmacyLocation.Handlers.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductOutput>();

            CreateMap<PaginatedListOutput<Product>, PaginatedListOutput<ProductOutput>>();
        }
    }
}