using AutoMapper;
using SkillManagement.Contracts.Dto.Categories;
using SkillManagement.Contracts.Dto.Practices;
using SkillManagement.Contracts.Dto.ProficiencyLevel;
using SkillManagement.Contracts.Dto.SkillsMatrix;
using SkillManagement.Contracts.Dto.TechnologyStack;
using SkillManagement.Data.Models;

namespace SkillManagement.Contracts
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Practices, PracticesDto>();
            CreateMap<Categories, CategoriesDto>();
            CreateMap<TechnologyStack, TechnologyStackDto>();

            CreateMap<ProficiencyLevel, ProficiencyLevelDto>();


            CreateMap<SkillsMatrixDto, SkillsMatrixResults>();
            CreateMap<SkillsMatrixDto, SkillsMatrixResults>().ReverseMap();
        }

    }
}