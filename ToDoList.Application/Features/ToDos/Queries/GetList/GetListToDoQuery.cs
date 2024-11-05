using AutoMapper;
using CorePackages.Application.Requests;
using CorePackages.Application.Responses;
using CorePackages.Persistence.Paging;
using MediatR;
using ToDoList.Application.Services.Repositories;
using ToDoList.Domain.Entities;
namespace ToDoList.Application.Features.ToDos.Queries.GetList;
public class GetListToDoQuery : IRequest<GetListResponse<GetListToDoListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public class GetListToDoQueryHandler(IToDoRepository toDoRepository, IMapper mapper)
    : IRequestHandler<GetListToDoQuery, GetListResponse<GetListToDoListItemDto>>
    {
        public async Task<GetListResponse<GetListToDoListItemDto>> Handle(GetListToDoQuery request, CancellationToken cancellationToken)
        {
            Paginate<ToDo> toDos = await toDoRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);
            GetListResponse<GetListToDoListItemDto> response = mapper.Map<GetListResponse<GetListToDoListItemDto>>(toDos);
            return response;
        }
    }
}
