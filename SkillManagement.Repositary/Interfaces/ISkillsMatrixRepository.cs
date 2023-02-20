using SkillManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.Repositary.Interfaces
{
    public interface ISkillMatrixRepository
    {
        Task<IEnumerable<SkillsMatrixResults>> GetAllSkills(string? skillName);

        Task<int> CreateSkill(List<TechnologySkillsMatrix> technologySkillsMatrix);

    }
}
