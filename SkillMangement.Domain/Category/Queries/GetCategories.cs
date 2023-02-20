using AutoMapper;
using SkillManagement.Contracts.Dto.Categories;
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
    public class GetCategories: ICategories
    {
        private readonly IMapper _mapper;
        private readonly ICategoriesRepository _categoriesRepository;

        public GetCategories(IMapper mapper, ICategoriesRepository categoriesRepository)
        {
            _mapper = mapper;
            _categoriesRepository = categoriesRepository;
        }
        public virtual async Task<IEnumerable<CategoriesDto>> Execute(int practiceId)
        {
            var result = await _categoriesRepository.GetAllCategories(practiceId);
            return _mapper.Map<IEnumerable<CategoriesDto>>(result);
        }
    }
}
