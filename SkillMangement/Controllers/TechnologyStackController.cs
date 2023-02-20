using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkillManagement.Data.Models;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.Domain.DomainInterfaces.Queries;
using SkillMangement.Domain.TechnologyStack.Queries;

namespace SkillManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyStackController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITechnologyStack _technologystack;

        public TechnologyStackController(IMapper mapper,
            ITechnologyStack technologystack)
        {
            this._mapper = mapper;
            this._technologystack = technologystack;
        }

        [HttpGet("GetTechnologyStack")]
        public async Task<ActionResult> GetTechnology(int? categoryId)
        {
            var result = await this._technologystack.ExecuteByCategoryId(categoryId);

            if (result == null)
            {
                throw new Exception($"Technology Stack for the CategoryId {categoryId} is not found.");
            }
          
            return Ok(result);
        }


        [HttpGet("GetAllTechnologyStack")]

        public async Task<ActionResult> GetAllTechnology()
        {
            var result = await this._technologystack.Execute();
            return Ok(result);
        }

        
    }
}
