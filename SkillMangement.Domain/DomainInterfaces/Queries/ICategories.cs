using SkillManagement.Contracts.Dto.Categories;
using SkillManagement.Contracts.Dto.Practices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMangement.Domain.DomainInterfaces.Queries
{
    public interface ICategories
    {
        Task<IEnumerable<CategoriesDto>> Execute(int practiceId);
    }

}
