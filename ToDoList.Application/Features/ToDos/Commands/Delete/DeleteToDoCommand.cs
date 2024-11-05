using AutoMapper;
using MediatR;
using ToDoList.Application.Services.Repositories;
using ToDoList.Domain.Entities;
namespace ToDoList.Application.Features.ToDos.Commands.Delete;
public class DeleteToDoCommand : IRequest<DeletedToDoResponse>
{
    public Guid Id { get; set; }
    public class DeleteToDoCommandHandler(IToDoRepository toDoRepository, IMapper mapper)
    : IRequestHandler<DeleteToDoCommand, DeletedToDoResponse>
    {
        public async Task<DeletedToDoResponse> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            ToDo? toDo = await toDoRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await toDoRepository.DeleteAsync(toDo);
            DeletedToDoResponse response = mapper.Map<DeletedToDoResponse>(toDo);
            return response;
        }
    }
}
