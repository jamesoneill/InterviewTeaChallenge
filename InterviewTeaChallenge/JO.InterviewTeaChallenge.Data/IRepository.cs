using JO.InterviewTeaChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JO.InterviewTeaChallenge.Data
{
    public partial interface IRepository<T> where T : BaseEntity
    {
        T GetById(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
    }
}
