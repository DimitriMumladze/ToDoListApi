using MediatR;
using ToDoListApi.Domain.Entities;

namespace ToDoListApi.Application.ToDoTasks.Queries.GetByIdToDoTasks;

public class GetByIdToDoTasksQuery(int id) : IRequest<ToDoTaskDto?> 
{
    public int Id { get; } = id;
}
