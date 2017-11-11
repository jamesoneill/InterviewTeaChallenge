using JO.InterviewTeaChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JO.InterviewTeaChallenge.Core.Services.Interfaces
{
    public interface ITeaService
    {
        Task<Guid> CreateTeaAsync(string name, bool requiresMilk);
        Task DeleteTeaAsync(Guid id);
        Task<Tea> GetTeaAsync(Guid id);
        Task<IReadOnlyCollection<Tea>> GetTeasAsync();
        Task UpdateTeaAsync(Guid id, string name, bool requiresMilk)
    }
}
