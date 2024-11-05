using AutoMapper;
using MediatR;
using ToDoList.Application.Services.Repositories;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Features.ToDos.Queries.GetById;
public class GetByIdToDoQuery : IRequest<GetByIdToDoResponse>
{
    public Guid Id { get; set; }
    public class GetByIdToDoQueryHandler(IToDoRepository toDoRepository, IMapper mapper)
    : IRequestHandler<GetByIdToDoQuery, GetByIdToDoResponse>
    {
        public async Task<GetByIdToDoResponse> Handle(GetByIdToDoQuery request, CancellationToken cancellationToken)
        {
            ToDo? toDo = await toDoRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            GetByIdToDoResponse response = mapper.Map<GetByIdToDoResponse>(toDo);
            return response;
        }
    }
}
    
