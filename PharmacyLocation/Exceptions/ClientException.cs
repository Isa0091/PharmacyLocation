using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Exceptions
{
    /// <summary>
    /// Represneta una excepcion por una opración inválida generada pr el sistema cliente
    /// </summary>
    public class ClientException : Isa0091.Domain.Core.Exceptions.DomainClientException<ClientExceptionType>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exceptionType"></param>
        /// <param name="relatedField"></param>
        /// <param name="relatedObject"></param>
        /// <param name="message"></param>
        protected ClientException(ClientExceptionType exceptionType, string relatedField, Type relatedObject, string message) : base(exceptionType, relatedField, relatedObject, message)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="relatedField"></param>
        /// <param name="relatedObject"></param>
        /// <param name="message">Opcional, si no se esopecifica se pone un mensaje generico indicando el campo y clase base </param>
        /// <returns></returns>
        public static ClientException CreateException(ClientExceptionType type, string relatedField,
            Type relatedObject, string? message = null)
        {
            return new ClientException(type, relatedField, relatedObject, message ?? GetMessage(type, relatedField, relatedObject));
        }
    }

    /// <summary>
    /// Todos los tipos de exceciones de cliente de Bitdesk
    /// </summary>
    public enum ClientExceptionType
    {
        /// <summary>
        /// 
        /// </summary>
        RequiredField = 100,
        /// <summary>
        /// 
        /// </summary>
        InvalidOperation = 101,
        /// <summary>
        /// Se especifico unvalor no valido para un campo
        /// </summary>
        InvalidFieldValue = 102,
        /// <summary>
        /// Cuando el tamaño de un campo es muy corto o muy largo
        /// </summary>
        InvalidFieldSize = 103,
        /// <summary>
        /// Cuando se trata de crear una entidad que ya existe.
        /// </summary>
        EntityAlreadyExist = 104,
        /// <summary>
        /// El OTP enviado noes valido para la cuenta
        /// </summary>
        InvalidOtp = 105,
        /// <summary>
        /// El token no es valido para la cuenta
        /// </summary>
        InvalidToken = 106,

        /// <summary>
        /// Indica que el token no se pudo guardar llamando a algun servicio de tokenizacion de tarjetas
        /// </summary>
        CardTokenNotPersist = 107
    }
}
