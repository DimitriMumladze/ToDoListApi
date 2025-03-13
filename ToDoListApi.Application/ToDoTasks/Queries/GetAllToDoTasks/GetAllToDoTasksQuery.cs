using MediatR;
using ToDoListApi.Domain.Entities;

namespace ToDoListApi.Application.ToDoTasks.Queries.GetAllToDoTasks;

public class GetAllToDoTasksQuery : IRequest<ICollection<ToDoTaskDto>?> { }

