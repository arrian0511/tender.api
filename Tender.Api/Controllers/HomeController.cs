using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tender.Shared;
using Tender.Services;
using Tender.Models;

namespace Tender.Api.Controllers
{
    [Route(TenderConstants.ApiRoutePrefix)]
    public class HomeController : Controller
    {
        private ITenderTaskManagementService _entityService;

        public HomeController(ITenderTaskManagementService entityService)
        {
            this._entityService = entityService;
        }

        // GET api/values
        [ProducesResponseType(typeof(ServiceResponse<IEnumerable<TenderTask>>), 200)]
        [HttpGet]
        public IActionResult Index()
        {
            var response = this._entityService.GetAllTasks();
            return StatusCode(response.StatusCode, response);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]TenderTask entity)
        {
            var response = this._entityService.CreateTask(entity);
            return StatusCode(response.StatusCode, response);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
