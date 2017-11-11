using JO.InterviewTeaChallenge.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using JO.InterviewTeaChallenge.Data.Models;
using JO.InterviewTeaChallenge.Data;
using System.Threading.Tasks;
using System.Linq;
using JO.InterviewTeaChallenge.Core.SafeExceptions;

namespace JO.InterviewTeaChallenge.Core.Services
{
    public class TeaService : ITeaService
    {
        private readonly IRepository<Tea> _teaRepository;
        public TeaService(IRepository<Tea> teaRepository)
        {
            _teaRepository = teaRepository;
        }
        public async Task<Guid> CreateTeaAsync(string name, bool requiresMilk)
        {
            var tea = new Tea()
            {
                Id = Guid.NewGuid(),
                Name = name,
                RequiresMilk = requiresMilk,
            };

            return await _teaRepository.Insert(tea);
        }

        public async Task DeleteTeaAsync(Guid id)
        {
            var tea = await _teaRepository.GetById(id);

            await _teaRepository.Delete(tea);
        }

        public async Task<Tea> GetTeaAsync(Guid id)
        {
            var tea =  await _teaRepository.GetById(id);

            return tea;
        }

        public async Task<IReadOnlyCollection<Tea>> GetTeasAsync()
        {
            var teas = await _teaRepository.Table;

            return teas.ToList();
        }

        public async Task UpdateTeaAsync(Guid id, string name, bool requiresMilk)
        {
            var tea = await _teaRepository.GetById(id);

            if (tea == null) throw new NotFoundException();

            tea.Name = name;
            tea.RequiresMilk = requiresMilk;

            await _teaRepository.Update(tea);
        }
    }
}
