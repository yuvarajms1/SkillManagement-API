using SkillManagement.Data.Models;
using SkillManagement.EF.Context;
using SkillManagement.Repositary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SkillManagement.Repositary
{
    public class CategoriesRepository : ICategoriesRepository
    {

        private readonly SkillManagementContext _context;

        public CategoriesRepository(SkillManagementContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Categories>> GetAllCategories(int practiceId)
        {

            

                return await _context.Set<Categories>().Where(x=>x.PracticesId == practiceId).ToListAsync();
        }

    }
}