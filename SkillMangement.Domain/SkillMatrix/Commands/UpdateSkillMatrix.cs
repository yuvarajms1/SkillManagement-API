using AutoMapper;
using SkillManagement.Contracts.Dto.SkillsMatrix;
using SkillManagement.Contracts.Dto.TechnologyStack;
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
  

    public class UpdateSkillMatrix: IUpdateSkillMatrix
    {
        private readonly IMapper _mapper;
        private readonly ISkillMatrixRepository _skillMatrixRepository;

        public UpdateSkillMatrix(IMapper mapper, ISkillMatrixRepository skillMatrixRepository)
        {
            _mapper = mapper;
            _skillMatrixRepository = skillMatrixRepository;
        }
        public virtual async Task<int> Execute(List<TechnologyStackDto> technologyStackDto)
        {
          
            List<TechnologySkillsMatrix> technologySkillMatrixList = new List<TechnologySkillsMatrix>();

            foreach(var technologyStack in technologyStackDto)
            {
               
                    TechnologySkillsMatrix techSkillMatrix = new TechnologySkillsMatrix();
                    techSkillMatrix.TechnologyId = technologyStack.Id;
                    techSkillMatrix.EmployeeName = "Yuvaraj S";
                    techSkillMatrix.ProficiencyLevelId = technologyStack.SelectedProficiencyLevel;
                    technologySkillMatrixList.Add(techSkillMatrix);
                  
            }

            var result = await _skillMatrixRepository.CreateSkill(technologySkillMatrixList);
            return result;
        }
    }
}
