using AutoMapper;
using MediatR;
using ToDoListApi.Application.ToDoTasks.Dtos;
using ToDoListApi.Domain.Repositories;

namespace ToDoListApi.Application.ToDoTasks.Queries.GetAllToDoTasks;

internal class GetAllToDoTasksQueryHandler(IMapper mapper,
    IToDoTasksRepository toDoTaskRepository) : IRequestHandler<GetAllToDoTasksQuery, IEnumerable<ToDoTaskDto>>
{
    public async Task<IEnumerable<ToDoTaskDto>> Handle(GetAllToDoTasksQuery request, CancellationToken cancellationToken)
    {
        var toDoTasks = toDoTaskRepository.GetAllToDoTasksAsync();

        var toDoTasksDto = mapper.Map<IEnumerable<ToDoTaskDto>>(toDoTasks);

        return toDoTasksDto;
    }
}
