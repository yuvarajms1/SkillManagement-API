using AutoMapper;
using SkillManagement.Contracts.Dto.Practices;
using SkillManagement.Contracts.Dto.TechnologyStack;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.Domain.DomainInterfaces.Queries;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMangement.Domain.TechnologyStack.Queries
{
    public class GetTechnologyStack: ITechnologyStack
    {
        private readonly IMapper _mapper;
        private readonly ITechnologyStackRepository _techstackRepository;

        public GetTechnologyStack(IMapper mapper, ITechnologyStackRepository techstackRepository)
        {
            _mapper = mapper;
            _techstackRepository = techstackRepository;
        }
  
        public virtual async Task<IEnumerable<TechnologyStackDto>> ExecuteByCategoryId(int? categoryId)
        {
            var result = await _techstackRepository.GetTechnologyByCategoryId(categoryId);
            return _mapper.Map<IEnumerable<TechnologyStackDto>>(result);
        }
    }
}
