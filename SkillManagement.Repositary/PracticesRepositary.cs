using SkillManagement.Data.Models;
using SkillManagement.EF.Context;
using SkillManagement.Repositary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SkillManagement.Repositary
{
    public class PracticesRepository : IPracticesRepository
    {

        private readonly SkillManagementContext _context;

        public PracticesRepository(SkillManagementContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Practices>> GetAllPractices()
        {
            return await _context.Set<Practices>().ToListAsync();
        }


    }
}