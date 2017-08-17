using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tender.Shared;
using Tender.Models.Infrastructure;

namespace Tender.Storage.Repository
{
    /// <summary>
    /// Entity Service Interface
    /// </summary>
    /// <typeparam name="T">[in] Entity Type</typeparam>
    public interface IEntityRepository<T>
            where T : Entity, new()
    {
        /// Get All Entity Data
        IEnumerable<T> GetAll();

        /// Get Entity By ID
        T GetById(Guid id);

        /// Create Entity
        void Create(T entity);

        /// Delete Entity
        void Delete(T entity);

        /// Delete Entity based on predicate
        void DeleteWhere(Expression<Func<T, bool>> predicate);

        /// Update Entity
        void Update(T entity);

        /// Commit Changes
        void Save();
    }
}
