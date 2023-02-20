using SkillManagement.Data.Models;
using SkillManagement.EF.Context;
using SkillManagement.Repositary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SkillManagement.Repositary
{
    public class ProficiencyLevelRepository : IProficiencyLevelRepository
    {

        private readonly SkillManagementContext _context;

        public ProficiencyLevelRepository(SkillManagementContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<ProficiencyLevel>> GetAllProficiencyLevels()
        {
            return await _context.Set<ProficiencyLevel>().ToListAsync();
        }

    }
}