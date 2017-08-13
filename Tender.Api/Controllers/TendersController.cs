using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tender.Shared;
using Tender.Services;
using Tender.Models;

namespace Tender.Api.Controllers
{
    [Route(TenderConstants.ApiRoutePrefix + "tenders")]
    public class TendersController : Controller
    {
        private ITenderTaskManagementService _entityService;

        public TendersController(ITenderTaskManagementService entityService)
        {
            this._entityService = entityService;
        }

        [ProducesResponseType(typeof(ServiceResponse<IEnumerable<TenderTask>>), 200)]
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var response = this._entityService.GetAllTasks();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(Guid id)
        {
            var response = this._entityService.GetTaskById(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody]TenderTask entity)
        {
            var response = this._entityService.CreateTask(entity);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateTask(Guid id, [FromBody]TenderTask entity)
        {
            var response = this._entityService.UpdateTask(id, entity);
            return StatusCode(response.StatusCode, response);
        }
    }
}
