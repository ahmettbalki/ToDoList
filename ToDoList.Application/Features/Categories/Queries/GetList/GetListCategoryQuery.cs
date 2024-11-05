using AutoMapper;
using CorePackages.Application.Requests;
using CorePackages.Application.Responses;
using CorePackages.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Services.Repositories;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Features.Categories.Queries.GetList;
public class GetListCategoryQuery : IRequest<GetListResponse<GetListCategoryByToDoListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public class GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) 
        : IRequestHandler<GetListCategoryQuery, GetListResponse<GetListCategoryByToDoListItemDto>>
    {
        public async Task<GetListResponse<GetListCategoryByToDoListItemDto>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            Paginate<Category> categories =  await categoryRepository.GetListAsync(
                include: c => c.Include(c => c.ToDos),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize);
            var response = mapper.Map<GetListResponse<GetListCategoryByToDoListItemDto>>(categories);
            return response;
        }
    }
}
