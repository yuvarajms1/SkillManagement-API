using SkillManagement.Contracts.Dto.Practices;
using SkillManagement.Contracts.Dto.TechnologyStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMangement.Domain.DomainInterfaces.Queries
{
    public interface ITechnologyStack
    {
        Task<IEnumerable<TechnologyStackDto>> Execute();

        Task<IEnumerable<TechnologyStackDto>> ExecuteByCategoryId(int? categoryId);
    }

}
