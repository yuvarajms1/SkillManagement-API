using SkillManagement.Data.Models;
using SkillManagement.EF.Context;
using SkillManagement.Repositary.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace SkillManagement.Repositary
{
    public class SkillsMatrixRepository : ISkillMatrixRepository
    {

        private readonly SkillManagementContext _context;

        public SkillsMatrixRepository(SkillManagementContext context)
        {
            this._context = context;
        }


        public async Task<IEnumerable<SkillsMatrixResults>> GetAllSkills(string? searchText)
        {
            if (searchText == null)
            {
                return null;
            }
            var searchTextParam = new SqlParameter("@SearchText", searchText);

           return await this._context.SkillsMatrixResults.FromSqlRaw("exec getTechnologyProficientlevelBySearchText @SearchText", searchTextParam).ToListAsync();

        }

        public async Task<int> CreateSkill(List<TechnologySkillsMatrix> technologySkillsMatrix)
        {
            foreach (var techSKillMatrix in technologySkillsMatrix)
            {

                var deleteItem = this._context.TechnologySkillsMatrix.Where(x => x.TechnologyId == techSKillMatrix.TechnologyId).FirstOrDefault();
                if(deleteItem!=null)
                {
                    this._context.TechnologySkillsMatrix.Remove(deleteItem);
                    this._context.SaveChanges();

                    await this._context.AddAsync(techSKillMatrix);
                    await this._context.SaveChangesAsync();
                }
                else
                {
                    await this._context.AddAsync(techSKillMatrix);
                    await this._context.SaveChangesAsync();
                }

                  

            }
            var res = 1;
            return res;
        }
    }
}