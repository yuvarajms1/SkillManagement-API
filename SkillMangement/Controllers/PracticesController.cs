using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkillManagement.Data.Models;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.Domain.Practices.Queries;
using SkillMangement.Domain.DomainInterfaces.Queries;

namespace SkillManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticesController : ControllerBase
    {
        private readonly IPractices _getPractices;

        public PracticesController(IPractices getPractices)
        {
          this._getPractices = getPractices;
        }


        [HttpGet("GetAllPractices")]

        public async Task<ActionResult> GetAllPractices()
        {
            var result = await this._getPractices.Execute();
            return Ok(result);
        }
    }
}
