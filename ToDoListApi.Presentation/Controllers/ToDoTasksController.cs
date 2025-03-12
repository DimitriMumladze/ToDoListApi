using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Application.ToDoTasks.Commands.ToDoTaskSingleCreate;
using ToDoListApi.Domain.Entities;
using ToDoListApi.Application.ToDoTasks.Queries.GetAllToDoTasks;
using ToDoListApi.Application.ToDoTasks.Queries.GetByIdToDoTasks;

namespace ToDoListApi.Presentation.Controllers;
[ApiController]
[Route("api/toDoTasks")]
public class ToDoTasksController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllToDoTasksQuery();
        var tasks = await mediator.Send(query);
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoTaskDto?>> GetById([FromRoute] int id)
    {
        var query = new GetByIdToDoTasksQuery(id);
        var task = await mediator.Send(query);
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody]ToDoTasksSingleCreateCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }
}
