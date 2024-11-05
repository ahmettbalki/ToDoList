using CorePackages.Persistence.Repositories;
using ToDoList.Domain.Entities;
namespace ToDoList.Application.Services.Repositories;
public interface IToDoRepository : IAsyncRepository<ToDo, Guid>
{
}