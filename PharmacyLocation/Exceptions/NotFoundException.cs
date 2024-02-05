using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Exceptions
{
    /// <summary>
    /// Represeta un error cuando se trata de consultar un objeto que no existe
    /// </summary>
    public class NotFoundException : Isa0091.Domain.Core.Exceptions.DomainNotFoundException<NotFoundExceptionType>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="relatedField"></param>
        /// <param name="relatedObject"></param>
        /// <returns></returns>
        public static NotFoundException CreateException(NotFoundExceptionType type, string relatedField,
            Type relatedObject)
        {
            return new NotFoundException(type, relatedField, relatedObject, GetMessage(type, relatedField, relatedObject));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="relatedField"></param>
        /// <param name="relatedObject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static NotFoundException CreateException(NotFoundExceptionType type, string relatedField,
            Type relatedObject, string message)
        {
            return new NotFoundException(type, relatedField, relatedObject, message);
        }

        protected NotFoundException(NotFoundExceptionType exceptionType, string relatedField, Type relatedObject, string message) : base(exceptionType, relatedField, relatedObject, message)
        {
        }
    }
    /// <summary>
    /// Lista de objetos del sistema
    /// </summary>
    public enum NotFoundExceptionType
    {
        /// <summary>
        /// 
        /// </summary>
        Pharmacy = 0,

        /// <summary>
        /// 
        /// </summary>
        Product = 1,

        /// <summary>
        /// 
        /// </summary>
        PharmacyProduct = 2
    }
}
