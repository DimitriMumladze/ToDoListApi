using MediatR;
using ToDoListApi.Application.ToDoTasks.Dtos;

namespace ToDoListApi.Application.ToDoTasks.Queries.GetByIdToDoTasks;

public class GetByIdToDoTasksQuery(int id) : IRequest<ToDoTaskDto?> 
{
    public int Id { get; } = id;
}
