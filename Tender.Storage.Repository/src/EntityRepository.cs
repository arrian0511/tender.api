using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tender.Shared;
using Tender.Models.Infrastructure;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace Tender.Storage.Repository
{
    public class EntityRepository<T> : IEntityRepository<T>
        where T : Entity, new()
    {
        private DbContext   _context;     // Context
        private DbSet<T>    _table;       // Table

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iContext">[in] Database Context</param>
        public EntityRepository(DbContext iContext)
        {
            /// Initialize Member Variables
            this._context = iContext;
            this._table = iContext.Set<T>();
        }

        /// <summary>
        /// Get All Entity Data
        /// </summary>
        /// <returns>Entity Data</returns>
        public virtual IEnumerable<T> GetAll()
        {
            /// Return Entity Data
            return this._table.AsEnumerable<T>();
        }

        /// <summary>
        /// Get Entity By ID
        /// </summary>
        /// <param name="id">[in] ID</param>
        /// <returns>Entity</returns>
        public virtual T GetById(Guid id)
        {
            /// Return Entity based on ID
            T entity = _table.Find(id);
            if (entity == null)
                throw new ArgumentNullException("Entity");
            return entity;
        }

        /// <summary>
        /// Create Entity
        /// </summary>
        /// <param name="entity">[in] Entity Record</param>
        public virtual void Create(T entity)
        {
            /// Insert Entity Record to Table
            if (entity == null)
                throw new ArgumentNullException("Entity");
            _context.Entry<T>(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity">[in] Entity Record</param>
        public virtual void Update(T entity)
        {
            /// Update Entity Record to Table
            if (entity == null)
                throw new ArgumentNullException("Entity");
            _context.Entry<T>(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity">[in] Entity Record</param>
        public virtual void Delete(T entity)
        {
            /// Delete Entity Record from Table
            if (entity == null)
                throw new ArgumentNullException("Entity");
            _table.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Delete Entity based on predicate
        /// </summary>
        /// <param name="predicate">[in] Predicate</param>
        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            /// Delete Entity Record from Table based on predicate
            bool hasDeleted = false;            // Has Deleted Flag
            foreach (var entity in GetAll())
            {
                if (predicate.Compile()(entity))
                {
                    _table.Remove(entity);
                    hasDeleted = true;
                    break;
                }
            }

            /// Save Record if there is deleted
            if (hasDeleted == true)
                _context.SaveChanges();
        }

        /// <summar>yg
        /// Commit Changes
        /// </summary>
        public virtual void Save()
        {
            /// Commit all Changes
            _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
