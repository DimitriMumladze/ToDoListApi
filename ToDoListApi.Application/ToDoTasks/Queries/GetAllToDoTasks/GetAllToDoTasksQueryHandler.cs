using AutoMapper;
using MediatR;
using ToDoListApi.Domain.Entities;
using ToDoListApi.Domain.Repositories;

namespace ToDoListApi.Application.ToDoTasks.Queries.GetAllToDoTasks;

public class GetAllToDoTasksQueryHandler : IRequestHandler<GetAllToDoTasksQuery, ICollection<ToDoTaskDto>?>
{
    private readonly IMapper _mapper;
    private readonly IToDoTasksRepository _toDoTaskRepository;

    public GetAllToDoTasksQueryHandler(IMapper mapper, IToDoTasksRepository toDoTaskRepository)
    {
        _mapper = mapper;
        _toDoTaskRepository = toDoTaskRepository;
    }

    public async Task<ICollection<ToDoTaskDto>?> Handle(GetAllToDoTasksQuery request, CancellationToken cancellationToken)
    {
        var toDoTasks = await _toDoTaskRepository.GetAllToDoTasksAsync(); 
        var toDoTasksDto = _mapper.Map<ICollection<ToDoTaskDto>?>(toDoTasks);
        return toDoTasksDto;
    }
}

