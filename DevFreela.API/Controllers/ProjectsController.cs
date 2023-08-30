using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProject;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
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
        public async Task<IActionResult> Get(string query)
        {
            var getAllProjectQuery = new GetAllProjectQuery(query);

            //var projects = _projectService.GetAll(query);
            var projects = await _mediator.Send(getAllProjectQuery);

            return Ok(projects);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            if (command.Title.Length > 50)
                return BadRequest();

            //var id = _projectService.Create(inputModel);
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            if (command.Description.Length > 200)
                return BadRequest();

            //_projectService.Update(inputModel);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);
            //_projectService.Delete(id);

            await _mediator.Send(command);

            return NoContent();
        }
        
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand command)
        {
            //_projectService.CreateComment(inputModel);
            await _mediator.Send(command);

            return NoContent();
        }
        
        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);

            //_projectService.Start(id);
            await _mediator.Send(command);

            return NoContent();
        }
        
        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);

            //_projectService.Finish(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
