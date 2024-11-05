using AutoMapper;
using MediatR;
using ToDoList.Application.Services.Repositories;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;

namespace ToDoList.Application.Features.ToDos.Commands.Update;
public class UpdateToDoCommand : IRequest<UpdatedToDoResponse>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Priority Priority { get; set; }
    public int CategoryId { get; set; }
    public bool Completed { get; set; }
    public class UpdateToDoCommandHandler(IToDoRepository toDoRepository, IMapper mapper)
    : IRequestHandler<UpdateToDoCommand, UpdatedToDoResponse>
    {
        public async Task<UpdatedToDoResponse> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            ToDo? toDo = await toDoRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            toDo = mapper.Map(request, toDo);
            await toDoRepository.UpdateAsync(toDo);
            UpdatedToDoResponse response = mapper.Map<UpdatedToDoResponse>(toDo);
            return response;
        }
    }
}
