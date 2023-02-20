using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkillManagement.Data.Models;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.Domain.DomainInterfaces.Queries;
using SkillMangement.Domain.SkillMatrix.Commands;
using SkillMangement.Domain.SkillMatrix.Queries;
using System.Net;

namespace SkillManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsMatrixController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISkillMatrix _skillMatrix;
        private readonly ICreateSkillMatrix _createSkillMatrix;
        private readonly IUpdateSkillMatrix _updateSkillMatrix;

        public SkillsMatrixController(IMapper mapper,
            ISkillMatrix skillMatrix, ICreateSkillMatrix createSkillMatrix, IUpdateSkillMatrix updateSkillMatrix)
        {
            this._mapper = mapper;
            this._skillMatrix = skillMatrix;
            this._createSkillMatrix = createSkillMatrix;
            this._updateSkillMatrix = updateSkillMatrix;
        }

        [HttpGet("GetSkillMatrix")]
        public async Task<ActionResult> GetTechnologySkillMatrix(string? skillName)
        {
            if (string.IsNullOrEmpty(skillName))
            {
                return Ok("To search, a word should be of 3 letters or more.");
            }

            if (skillName.Trim().Length <3)
            {
                return Ok("To search, a word should be of 3 letters or more.");
            }
            
           var skillResults = await this._skillMatrix.Execute(skillName);

            if (skillResults == null)
            {
                throw new Exception($"Skill Matrix for the Skill {skillName} is not found.");
            }

            return Ok(skillResults);
        }

        [HttpPost]
        [Route("CreateSkillsMatrix")]
        public async Task<ActionResult> CreateSkillsMatrixOnSearch([FromBody] List<Contracts.Dto.SkillsMatrix.SkillsMatrixDto> skillMatrixDto)
        {
            try
            {
                await this._createSkillMatrix.Execute(skillMatrixDto);
                return NoContent();
            }
          
            catch (DbUpdateException ex)
            {
              return Conflict(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateSkillsMatrix")]
        public async Task<ActionResult> UpdateSkillsMatrix([FromBody] List<Contracts.Dto.TechnologyStack.TechnologyStackDto> technologyStack)
        {
            try
            {
                await this._updateSkillMatrix.Execute(technologyStack);
                return NoContent();
            }

            catch (DbUpdateException ex)
            {
                return Conflict(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }



    }
}
