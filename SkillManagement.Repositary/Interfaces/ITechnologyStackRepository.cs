using SkillManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.Repositary.Interfaces
{
    public interface ITechnologyStackRepository
    {
        Task<IEnumerable<TechnologyStack>?> GetTechnologyByCategoryId(int? categoryId);

        Task<IEnumerable<TechnologyStack>> GetAllTechnology();

    }
}
