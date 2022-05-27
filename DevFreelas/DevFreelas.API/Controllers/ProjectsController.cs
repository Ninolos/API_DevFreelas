using DevFreelas.API.Models;
using DevFreelas.Application.Commands.CreateComment;
using DevFreelas.Application.Commands.CreateProjects;
using DevFreelas.Application.Commands.DeleteProjects;
using DevFreelas.Application.Commands.FinishProjects;
using DevFreelas.Application.Commands.StartProjects;
using DevFreelas.Application.Commands.UpdateProjects;
using DevFreelas.Application.InputModels;
using DevFreelas.Application.Services.Interfaces;
using MediatR;
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
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;

        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;

        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _projectService.GetAll(query);
            return Ok(projects);
        }
                
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var projects = _projectService.GetById(id);

            if(projects == null)
            {
                return NotFound();
            }
            return Ok(projects);            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            if(command.Title.Length > 50)
            {
                return BadRequest();
            }

            //var id =_projectService.Create(inputModel);
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id}, command);
        }

        
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            if (command.Description.Length > 200)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }       

    }
}
