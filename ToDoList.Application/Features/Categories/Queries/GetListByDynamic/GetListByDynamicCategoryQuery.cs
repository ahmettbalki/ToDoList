using AutoMapper;
using CorePackages.Application.Requests;
using CorePackages.Application.Responses;
using CorePackages.Persistence.Dynamic;
using CorePackages.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Features.Categories.Queries.GetList;
using ToDoList.Application.Services.Repositories;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Features.Categories.Queries.GetListByDynamic;

public class GetListByDynamicCategoryQuery : IRequest<GetListResponse<GetListByDynamicCategoryByToDoListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    public class GetListByDynamicCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        : IRequestHandler<GetListByDynamicCategoryQuery, GetListResponse<GetListByDynamicCategoryByToDoListItemDto>>
    {
        public async Task<GetListResponse<GetListByDynamicCategoryByToDoListItemDto>> Handle(GetListByDynamicCategoryQuery request, CancellationToken cancellationToken)
        {
            Paginate<Category> categories = await categoryRepository.GetListByDynamicAsync(
                request.DynamicQuery,
                include: c => c.Include(c => c.ToDos),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize);
            var response = mapper.Map<GetListResponse<GetListByDynamicCategoryByToDoListItemDto>>(categories);
            return response;
        }
    }
}
