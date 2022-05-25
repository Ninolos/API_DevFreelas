using DevFreelas.API.Models;
using DevFreelas.Application.InputModels;
using DevFreelas.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreelas.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
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
        public IActionResult Post([FromBody] NewProjectInputModel inputModel)
        {
            if(inputModel.Title.Length > 50)
            {
                return BadRequest();
            }

            var id =_projectService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id}, inputModel);
        }

        
        [HttpPut]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputModel)
        {
            if (inputModel.Description.Length > 200)
            {
                return BadRequest();
            }

            _projectService.Update(inputModel);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _projectService.Delete(id);

           return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel inputModel)
        {
            _projectService.CreateComment(inputModel);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);

            return NoContent();
        }       

    }
}
