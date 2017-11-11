using JO.InterviewTeaChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JO.InterviewTeaChallenge.Data
{
    public partial class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        private IList<T> _entities;

        public async Task<T> GetById(Guid id)
        {
            return await Task.FromResult<T>(Entities.FirstOrDefault(m => m.Id == id));
        }

        public async Task<Guid> Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Add(entity);

            return await Task.FromResult(entity.Id);
        }

        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }

        public async Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await Task.FromResult(Entities.Remove(entity));
        }

        public Task<IQueryable<T>> Table
        {
            get
            {
                return Task.FromResult<IQueryable<T>>(Entities.AsQueryable());
            }
        }

        protected IList<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = new List<T>();

                return _entities;
            }
        }
    }

}
