﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManagerApi.Business.Interface;

namespace TaskManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentTasksController : ControllerBase
    {
        private readonly IService<Model.ParentTask> parentTaskService;
        private readonly ILogger<ParentTasksController> logger;

        public ParentTasksController(IService<Model.ParentTask> parentTaskService, ILogger<ParentTasksController> logger)
        {
            this.parentTaskService = parentTaskService;
            this.logger = logger;
        }

        /// <summary>
        /// Retrieves all parent tasks.
        /// </summary>
        /// <returns>List of parent tasks</returns>
        [HttpGet(Name = "parentTask_query")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Model.ParentTask>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var tasks = await this.parentTaskService.GetAll();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server error.");
            }

        }
    }
}
