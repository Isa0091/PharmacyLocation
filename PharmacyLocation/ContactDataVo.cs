using Isa0091.Domain.Core.ValueObjects;
using PharmacyLocation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PharmacyLocation
{
    public class ContactDataVo : IValidatedValueObject
    {
        /// <summary>
        /// Numero fijo
        /// </summary>
        public string? LandLineNumber { get; init; }
        /// <summary>
        /// 
        /// </summary>
        public string? Email { get; init; }
        /// <summary>
        /// 
        /// </summary>
        public string? MobileNumber { get; init; }

        public void IsValid()
        {
            if (string.IsNullOrEmpty(LandLineNumber) && string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(MobileNumber))
                throw ClientException.CreateException(ClientExceptionType.RequiredField, "LandLineNumber-MobileNumber-Email", this.GetType(), "Debe de ingresar al menos un contacto");
        }
    }
}
