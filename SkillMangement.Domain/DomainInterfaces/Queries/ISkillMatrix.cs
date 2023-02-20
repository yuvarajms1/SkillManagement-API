using SkillManagement.Contracts.Dto.Practices;
using SkillManagement.Contracts.Dto.SkillsMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMangement.Domain.DomainInterfaces.Queries
{
    public interface ISkillMatrix
    {
        Task<IEnumerable<SkillsMatrixDto>> Execute(string? skillName);
    }

}
