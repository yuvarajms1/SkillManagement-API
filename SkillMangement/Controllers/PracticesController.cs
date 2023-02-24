using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkillManagement.Data.Models;
using SkillManagement.Repositary.Interfaces;
using SkillMangement.Domain.Practices.Queries;
using SkillMangement.Domain.DomainInterfaces.Queries;
using System.Net;
using SkillMangement.API.Logging;

namespace SkillManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticesController : ControllerBase
    {
        private readonly IPractices _getPractices;
        private static readonly ILogger Log = LogManager.CreateLogger(typeof(PracticesController).FullName);
        public PracticesController(IPractices getPractices)
        {
          this._getPractices = getPractices;
        }


        [HttpGet("GetAllPractices")]

        public async Task<ActionResult> GetAllPractices()
        {
            try
            {
                var result = await this._getPractices.Execute();
                return Ok(result);
            }
            catch (Exception e)
            {
                Log.LogError($"Failed to get practices. Exception: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
