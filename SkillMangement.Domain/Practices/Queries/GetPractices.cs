using AutoMapper;
using SkillManagement.Contracts.Dto.Practices;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.Domain.DomainInterfaces.Queries;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMangement.Domain.Practices.Queries
{
    public class GetPractices: IPractices
    {
        private readonly IMapper _mapper;
        private readonly IPracticesRepository _practicesRepository;

        public GetPractices(IMapper mapper, IPracticesRepository practicesRepository)
        {
            _mapper = mapper;
            _practicesRepository = practicesRepository;
        }
        public virtual async Task<IEnumerable<PracticesDto>> Execute()
        {
            var result = await _practicesRepository.GetAllPractices();
            return _mapper.Map<IEnumerable<PracticesDto>>(result);
        }
    }
}
