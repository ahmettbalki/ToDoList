using CorePackages.Persistence.Repositories;
namespace ToDoList.Domain.Entities;
public class Category : Entity<int>
{
    public string Name { get; set; }
    public List<ToDo> ToDos { get; set; }
}
