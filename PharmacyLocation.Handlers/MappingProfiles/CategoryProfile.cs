using AutoMapper;
using PharmacyLocation.Core;
using PharmacyLocation.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Handlers.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryOutput>();

            CreateMap<PaginatedListOutput<Category>, PaginatedListOutput<CategoryOutput>>();
        }
    }
}