using JO.InterviewTeaChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JO.InterviewTeaChallenge.Data
{
    public partial interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(Guid id);
        Task<Guid> Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<IList<T>> Table { get; }
    }
}
