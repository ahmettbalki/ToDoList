using AutoMapper;
using MediatR;
using ToDoList.Application.Features.ToDos.Rules;
using ToDoList.Application.Services.Repositories;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;
namespace ToDoList.Application.Features.ToDos.Commands.Create;
public class CreateToDoCommand : IRequest<CreatedToDoResponse>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Priority Priority { get; set; }
    public int CategoryId { get; set; }
    public bool Completed { get; set; }
    public string UserId { get; set; }
    public class CreateToDoCommandHandler(IToDoRepository toDoRepository,
        IMapper mapper,
        ToDoBusinessRules toDoBusinessRules)
    : IRequestHandler<CreateToDoCommand, CreatedToDoResponse>
    {
        public async Task<CreatedToDoResponse>? Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            await toDoBusinessRules.ToDoNameCannotBeDuplicatedWhenInserted(request.Title);
            ToDo toDo = mapper.Map<ToDo>(request);
            toDo.Id = Guid.NewGuid();
            await toDoRepository.AddAsync(toDo);
            CreatedToDoResponse response = mapper.Map<CreatedToDoResponse>(toDo);
            return response;
        }
    }
}
