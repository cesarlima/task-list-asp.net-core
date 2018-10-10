using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskList.API.Queries;
using TaskList.Domain.Commands;
using TaskList.Domain.Handlers;

namespace TaskList.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskHandler _hander;

        public TaskController(TaskHandler hander)
        {
            _hander = hander;
        }

        [HttpPost("v1/tasks")]
        public IActionResult Post(TaskRegisterCommand command)
        {
            try
            {
                var result = _hander.Handler(command);
                return Ok(result);
            }
            catch (Exception)
            {
                // tratamento de erros, logs etc...
                throw;
            }
        }

        [HttpGet("v1/tasks")]
        public IActionResult Get([FromServices]TaskQueries queries)
        {
            try
            {
                return Ok(queries.GetAll());
            }
            catch (Exception)
            {
                // tratamento de erros, logs etc...
                throw;
            }
        }

        [HttpPut("v1/tasks/toggle")]
        public IActionResult Completed(ToggleTaskCommand command)
        {
            try
            {
                var result = _hander.Handler(command);
                return Ok(result);
            }
            catch (Exception)
            {
                // tratamento de erros, logs etc...
                throw;
            }
        }

        [HttpDelete("v1/tasks/{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var result = _hander.Handler(new DeleteTaskCommand() { Id = id });
                return Ok(result);
            }
            catch (Exception)
            {
                // tratamento de erros, logs etc...
                throw;
            }
        }
    }
}