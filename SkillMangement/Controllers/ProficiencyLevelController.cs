using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkillManagement.Data.Models;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.API.Logging;
using SkillMangement.Domain.DomainInterfaces.Queries;
using SkillMangement.Domain.ProficiencyLevel.Queries;
using System.Net;

namespace SkillManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProficiencyLevelController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProficiencyLevel _proficiencyLevel;
        private static readonly ILogger Log = LogManager.CreateLogger(typeof(ProficiencyLevelController).FullName);

        public ProficiencyLevelController(IMapper mapper,
            IProficiencyLevel proficiencyLevel)
        {
            this._mapper = mapper;
            this._proficiencyLevel = proficiencyLevel;
        }

        [HttpGet("GetAllLevels")]

        public async Task<ActionResult> GetAllProficiencyLevels()
        {
            try
            {
                var result = await this._proficiencyLevel.Execute();
                return Ok(result);
            }
            catch (Exception e)
            {
                Log.LogError($"Failed to get proficiencyLevel. Exception: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
