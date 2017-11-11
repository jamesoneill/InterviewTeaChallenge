using JO.InterviewTeaChallenge.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JO.InterviewTeaChallenge.Data
{
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TeaContext _context;
        private DbSet<T> _entities;

        public EfRepository(TeaContext context)
        {
            _context = context;
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await Entities.FindAsync(id);
        }

        public virtual async Task<Guid> Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await Entities.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public virtual async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual Task<IQueryable<T>> Table
        {
            get
            {
                return Task.FromResult<IQueryable<T>>(Entities);
            }
        }

        public virtual Task<IQueryable<T>> TableNoTracking
        {
            get
            {
                return Task.FromResult<IQueryable<T>>(Entities.AsNoTracking<T>());
            }
        }

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
    }

}
