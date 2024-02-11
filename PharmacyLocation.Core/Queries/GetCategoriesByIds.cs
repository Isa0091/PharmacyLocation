using Isa0091.Domain.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core.Queries
{
    public class GetCategoriesByIds : QueryBase<List<Category>>
    {
        /// <summary>
        /// 
        /// </summary>
       public  List<string> CategoriesIds {  get; set; }
    }
}
