using DevFreelas.API.Models;
using DevFreelas.Application.Commands.CreateComment;
using DevFreelas.Application.Commands.CreateProjects;
using DevFreelas.Application.Commands.DeleteProjects;
using DevFreelas.Application.Commands.FinishProjects;
using DevFreelas.Application.Commands.StartProjects;
using DevFreelas.Application.Commands.UpdateProjects;
using DevFreelas.Application.InputModels;
using DevFreelas.Application.Queries.GetAllProjects;
using DevFreelas.Application.Queries.GetProjectById;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreelas.API.Controllers
{
    [Route("api/projects")]
    
    public class ProjectsController : ControllerBase
    {
        
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProjectsQuery = new GetAllProjectsQuery(query);

            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }
                
        [HttpGet("{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetById(int id)
        {
            var getProjectByIdQuery = new GetProjectByIdQuery(id);

            var projects = await _mediator.Send(getProjectByIdQuery);

            if (projects == null)
            {
                return NotFound();
            }
            return Ok(projects);            
        }

        [HttpPost]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            
            //var id =_projectService.Create(inputModel);
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id}, command);
        }

        
        [HttpPut]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(message);
            }

            await _mediator.Send(command);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }       

    }
}
