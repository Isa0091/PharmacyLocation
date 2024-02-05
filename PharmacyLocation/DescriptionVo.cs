using Isa0091.Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation
{
    /// <summary>
    /// Descripciones
    /// </summary>
    public class DescriptionVo : IValidatedValueObject
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public void IsValid()
        {
        }
    }
}
