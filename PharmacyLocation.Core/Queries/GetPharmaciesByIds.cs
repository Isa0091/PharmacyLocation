using Isa0091.Domain.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core.Queries
{
    public class GetPharmaciesByIds : QueryBase<List<Pharmacy>>
    {
        /// <summary>
        /// 
        /// </summary>
       public  List<string> PharmaciesIds {  get; set; }
    }
}
