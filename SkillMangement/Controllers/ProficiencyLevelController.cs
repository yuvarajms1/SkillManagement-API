using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkillManagement.Data.Models;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.Domain.DomainInterfaces.Queries;
using SkillMangement.Domain.ProficiencyLevel.Queries;

namespace SkillManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProficiencyLevelController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProficiencyLevel _proficiencyLevel;

        public ProficiencyLevelController(IMapper mapper,
            IProficiencyLevel proficiencyLevel)
        {
            this._mapper = mapper;
            this._proficiencyLevel = proficiencyLevel;
        }

        [HttpGet("GetAllLevels")]

        public async Task<ActionResult> GetAllProficiencyLevels()
        {
            var result = await this._proficiencyLevel.Execute();
            return Ok(result);
        }
    }
}
