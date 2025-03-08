using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Application.ToDoTasks.Dtos;
using ToDoListApi.Application.ToDoTasks.Queries.GetAllToDoTasks;

namespace ToDoListApi.Presentation.Controllers;
[Controller]
[Route("api/toDoTasks")]
public class ToDoTasksController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoTaskDto>>> GetAll([FromRoute] GetAllToDoTasksQuery query)
    {
        var task = await mediator.Send(query);
        return Ok(task);
    }
}
