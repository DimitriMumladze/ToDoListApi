using AutoMapper;
using MediatR;
using ToDoListApi.Application.ToDoTasks.Dtos;
using ToDoListApi.Domain.Repositories;

namespace ToDoListApi.Application.ToDoTasks.Queries.GetAllToDoTasks;

public class GetAllToDoTasksQueryHandler : IRequestHandler<GetAllToDoTasksQuery, IEnumerable<ToDoTaskDto>>
{
    private readonly IMapper _mapper;
    private readonly IToDoTasksRepository _toDoTaskRepository;

    public GetAllToDoTasksQueryHandler(IMapper mapper, IToDoTasksRepository toDoTaskRepository)
    {
        _mapper = mapper;
        _toDoTaskRepository = toDoTaskRepository;
    }

    public async Task<IEnumerable<ToDoTaskDto>> Handle(GetAllToDoTasksQuery request, CancellationToken cancellationToken)
    {
        var toDoTasks = await _toDoTaskRepository.GetAllToDoTasksAsync(); // 🛠️ Missing `await` fixed
        return _mapper.Map<IEnumerable<ToDoTaskDto>>(toDoTasks);
    }
}

