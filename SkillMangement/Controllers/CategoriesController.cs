using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkillManagement.Data.Models;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.API.Logging;
using SkillMangement.Domain.DomainInterfaces.Queries;
using SkillMangement.Domain.Practices.Queries;
using System.Collections.Generic;
using System.Net;

namespace SkillManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategories _getCategories;
        private static readonly ILogger Log = LogManager.CreateLogger(typeof(CategoriesController).FullName);

        public CategoriesController(IMapper mapper,
            ICategories getCategories)
        {
            this._mapper = mapper;
            this._getCategories = getCategories;
        }
       
        [HttpGet("GetAllCategories")]
        public async Task<ActionResult> GetAllCategories(int practicesId)
        {
            try
            {
                var result = await this._getCategories.Execute(practicesId);
                return Ok(result);
            }
            catch (Exception e)
            {
                Log.LogError($"Failed to get categories for the practice id {practicesId}. Exception: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
