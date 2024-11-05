using AutoMapper;
using CorePackages.Application.Responses;
using CorePackages.Persistence.Paging;
using ToDoList.Application.Features.Categories.Queries.GetList;
using ToDoList.Domain.Entities;
namespace ToDoList.Application.Features.Categories.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, GetListCategoryByToDoListItemDto>()
            .ForMember(destinationMember: c => c.ToDoName, memberOptions: opt => opt.MapFrom(c => c.ToDos))
            .ReverseMap();
        CreateMap<Paginate<Category>, GetListResponse<GetListCategoryByToDoListItemDto>>().ReverseMap();
    }
}
