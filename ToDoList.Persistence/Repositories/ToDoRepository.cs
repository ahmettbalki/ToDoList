using CorePackages.Persistence.Repositories;
using ToDoList.Application.Services.Repositories;
using ToDoList.Domain.Entities;
using ToDoList.Persistence.Contexts;
namespace ToDoList.Persistence.Repositories;
public class ToDoRepository : EfRepositoryBase<ToDo, Guid, BaseDbContext>, IToDoRepository
{
    public ToDoRepository(BaseDbContext context) : base(context)
    {
    }
}