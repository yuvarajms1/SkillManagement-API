using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkillManagement.Data.Models;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.Domain.DomainInterfaces.Queries;
using SkillMangement.Domain.Practices.Queries;

namespace SkillManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategories _getCategories;

        public CategoriesController(IMapper mapper,
            ICategories getCategories)
        {
            this._mapper = mapper;
            this._getCategories = getCategories;
        }
       
        [HttpGet("GetAllCategories")]
        public async Task<ActionResult> GetAllCategories(int practicesId)
        {
            var result = await this._getCategories.Execute(practicesId);
            return Ok(result);
        }
    }
}
