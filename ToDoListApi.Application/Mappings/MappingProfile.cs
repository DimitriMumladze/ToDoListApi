using AutoMapper;
using ToDoListApi.Application.ToDoTasks.Dtos;
using ToDoListApi.Domain.Entities;

namespace ToDoListApi.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ToDoTask, ToDoTaskDto>().ReverseMap();
    }
}
