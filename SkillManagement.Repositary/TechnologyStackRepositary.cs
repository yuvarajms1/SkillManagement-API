using SkillManagement.Data.Models;
using SkillManagement.EF.Context;
using SkillManagement.Repositary.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace SkillManagement.Repositary
{
    public class TechnologyStackRepository : ITechnologyStackRepository
    {

        private readonly SkillManagementContext _context;

        public TechnologyStackRepository(SkillManagementContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<TechnologyStack>> GetAllTechnology()
        {
            return await _context.Set<TechnologyStack>().ToListAsync();
        }

        public async Task<IEnumerable<TechnologyStack>> GetTechnologyByCategoryId(int? categoryId)
        {
            if (categoryId == null)
            {
                return null;
            }
            var cateGoryIdParam = new SqlParameter("@CatageryId", categoryId);

            return await this._context.TechnologyStack.FromSqlRaw("exec getTechnologyByCatageryID @CatageryId", cateGoryIdParam).ToListAsync();
              
        }

    }
}