using ToDoList.Domain.Enums;
namespace ToDoList.Application.Features.ToDos.Commands.Create;
public class CreatedToDoResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Priority Priority { get; set; }
    public int CategoryId { get; set; }
    public bool Completed { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedDate { get; set; }
}