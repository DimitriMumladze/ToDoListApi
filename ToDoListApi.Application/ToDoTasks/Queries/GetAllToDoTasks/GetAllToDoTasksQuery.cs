using MediatR;
using ToDoListApi.Application.ToDoTasks.Dtos;

namespace ToDoListApi.Application.ToDoTasks.Queries.GetAllToDoTasks;

public class GetAllToDoTasksQuery : IRequest<IEnumerable<ToDoTaskDto>> { }

