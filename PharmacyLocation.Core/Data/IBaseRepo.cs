using Isa0091.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core.Data
{
    /// <summary>
    /// Repo base parafacilitar la creacion de los otros repsitorios
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepo<TEntity> where TEntity : RootEntity
    {
        /// <summary>
        /// Agrega una entidad
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        Task AddAsync(TEntity entidad);

        /// <summary>
        /// Actualiza una entidad
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entidad);

        /// <summary>
        /// Remueve unelemento
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        Task RemoveAsync(TEntity entidad);

        /// <summary>
        /// Guarda los cambios
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}

