using SkillManagement.Contracts.Dto.Practices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMangement.Domain.DomainInterfaces.Queries
{
    public interface IPractices
    {
        Task<IEnumerable<PracticesDto>> Execute();
    }

}
