using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Exceptions
{
    public class ForbiddenException : Isa0091.Domain.Core.Exceptions.DomainForbiddenException
    {
        protected ForbiddenException()
        {
        }

        /// <summary>
        /// Crear la excepcion
        /// </summary>
        /// <returns></returns>
        public static ForbiddenException CreateException()
        {
            return new ForbiddenException();
        }

    }
}
