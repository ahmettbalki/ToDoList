using AutoMapper;
using CorePackages.Application.Responses;
using CorePackages.Persistence.Paging;
using ToDoList.Application.Features.ToDos.Commands.Create;
using ToDoList.Application.Features.ToDos.Commands.Delete;
using ToDoList.Application.Features.ToDos.Commands.Update;
using ToDoList.Application.Features.ToDos.Queries.GetById;
using ToDoList.Application.Features.ToDos.Queries.GetList;
using ToDoList.Domain.Entities;
namespace ToDoList.Application.Features.ToDos.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ToDo, CreateToDoCommand>().ReverseMap();
        CreateMap<ToDo, CreatedToDoResponse>().ReverseMap();
        CreateMap<ToDo, UpdateToDoCommand>().ReverseMap();
        CreateMap<ToDo, UpdatedToDoResponse>().ReverseMap();
        CreateMap<ToDo, DeletedToDoResponse>().ReverseMap();
        CreateMap<ToDo, DeleteToDoCommand>().ReverseMap();
        CreateMap<ToDo, GetListToDoListItemDto>().ReverseMap();
        CreateMap<ToDo, GetByIdToDoResponse>().ReverseMap();
        CreateMap<Paginate<ToDo>, GetListResponse<GetListToDoListItemDto>>().ReverseMap();
    }
}