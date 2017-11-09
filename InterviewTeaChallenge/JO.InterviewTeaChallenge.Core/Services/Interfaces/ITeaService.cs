using JO.InterviewTeaChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JO.InterviewTeaChallenge.Core.Services.Interfaces
{
    public interface ITeaService
    {
        /// <summary>
        /// Creates a new tea
        /// </summary>
        /// <param name="tea">The tea instance</param>
        /// <returns>The ID of the new tea</returns>
        int CreateTea(Tea tea);

        /// <summary>
        /// Deletes the tea with the given ID
        /// </summary>
        /// <param name="id">The ID of the tea to delete</param>
        void DeleteTea(int id);

        /// <summary>
        /// Gets the tea with the given ID
        /// </summary>
        /// <param name="id">The ID of the tea</param>
        /// <returns>The tea instance</returns>
        Tea GetTea(int id);

        /// <summary>
        /// Gets the set of teas
        /// </summary>
        /// <returns>The set of teas</returns>
        IReadOnlyCollection<Tea> GetTeas();

        /// <summary>
        /// Updates the given tea
        /// </summary>
        /// <param name="id">The ID of the tea</param>
        /// <param name="tea">The updated tea</param>
        void UpdateTea(int id, Tea tea);
    }
}
