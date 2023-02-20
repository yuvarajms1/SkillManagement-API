using AutoMapper;
using SkillManagement.Contracts.Dto.SkillsMatrix;
using SkillManagement.Data.Models;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.Domain.DomainInterfaces.Queries;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMangement.Domain.SkillMatrix.Commands
{
  

    public class CreateSkillMatrix: ICreateSkillMatrix
    {
        private readonly IMapper _mapper;
        private readonly ISkillMatrixRepository _skillMatrixRepository;

        public CreateSkillMatrix(IMapper mapper, ISkillMatrixRepository skillMatrixRepository)
        {
            _mapper = mapper;
            _skillMatrixRepository = skillMatrixRepository;
        }
        public virtual async Task<int> Execute(List<SkillsMatrixDto> skillMatrixtoList)
        {
          
            List<TechnologySkillsMatrix> technologySkillMatrixList = new List<TechnologySkillsMatrix>();

            foreach(var skillMatrixDto in skillMatrixtoList)
            {
                var techIndex = 0;
                foreach(var techStack in skillMatrixDto.TechnologyStack)
                {
                    TechnologySkillsMatrix techSkillMatrix = new TechnologySkillsMatrix();
                    techSkillMatrix.TechnologyId = skillMatrixDto.TechnologyStack[techIndex].Id;
                    techSkillMatrix.EmployeeName = "Yuvaraj S";
                    techSkillMatrix.ProficiencyLevelId = skillMatrixDto.TechnologyStack[techIndex].SelectedProficiencyLevel;
                    technologySkillMatrixList.Add(techSkillMatrix);
                    techIndex++;
                }
            }

            var result = await _skillMatrixRepository.CreateSkill(technologySkillMatrixList);
            return result;
        }
    }
}
