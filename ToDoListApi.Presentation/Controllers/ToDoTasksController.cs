using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Application.ToDoTasks.Dtos;
using ToDoListApi.Application.ToDoTasks.Queries.GetAllToDoTasks;

namespace ToDoListApi.Presentation.Controllers;
[ApiController]
[Route("api/toDoTasks")]
public class ToDoTasksController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        GetAllToDoTasksQuery query = new GetAllToDoTasksQuery();
        var task = await mediator.Send(query);
        return Ok(task);
    }
}
