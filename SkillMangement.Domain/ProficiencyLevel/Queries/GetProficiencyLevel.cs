using AutoMapper;
using SkillManagement.Contracts.Dto.Practices;
using SkillManagement.Contracts.Dto.ProficiencyLevel;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.Domain.DomainInterfaces.Queries;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMangement.Domain.ProficiencyLevel.Queries
{

    public class GetProficiencyLevel: IProficiencyLevel
    {
        private readonly IMapper _mapper;
        private readonly IProficiencyLevelRepository _plevelRepository;

        public GetProficiencyLevel(IMapper mapper, IProficiencyLevelRepository plevelRepository)
        {
            _mapper = mapper;
            _plevelRepository = plevelRepository;
        }
        public virtual async Task<IEnumerable<ProficiencyLevelDto>> Execute()
        {
            var result = await _plevelRepository.GetAllProficiencyLevels();
            return _mapper.Map<IEnumerable<ProficiencyLevelDto>>(result);
        }
    }
}
