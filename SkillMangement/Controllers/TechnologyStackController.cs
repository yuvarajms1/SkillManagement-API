using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkillManagement.Data.Models;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.API.Logging;
using SkillMangement.Domain.DomainInterfaces.Queries;
using SkillMangement.Domain.TechnologyStack.Queries;
using System.Net;

namespace SkillManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyStackController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITechnologyStack _technologystack;
        private static readonly ILogger Log = LogManager.CreateLogger(typeof(TechnologyStackController).FullName);
        public TechnologyStackController(IMapper mapper,
            ITechnologyStack technologystack)
        {
            this._mapper = mapper;
            this._technologystack = technologystack;
        }

        [HttpGet("GetTechnologyStack")]
        public async Task<ActionResult> GetTechnology(int? categoryId)
        {
            try
            {
                var result = await this._technologystack.ExecuteByCategoryId(categoryId);

                if (result == null)
                {
                    throw new Exception($"Technology Stack for the CategoryId {categoryId} is not found.");
                }

                return Ok(result);
            }

            catch (Exception e)
            {
                Log.LogError($"Failed to get Technology stack. Exception: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        
    }
}
