using CorePackages.Application.Rules;
using CorePackages.CrossCuttingConcerns.Exceptions.Types;
using ToDoList.Application.Features.ToDos.Constants;
using ToDoList.Application.Services.Repositories;
using ToDoList.Domain.Entities;
namespace ToDoList.Application.Features.ToDos.Rules;
public class ToDoBusinessRules(IToDoRepository toDoRepository) : BaseBusinessRules
{
    public async Task ToDoNameCannotBeDuplicatedWhenInserted(string name)
    {
        ToDo? result = await toDoRepository.GetAsync(predicate: t => t.Title.ToLower() == name.ToLower());
        if (result != null)
        {
            throw new BusinessException(ToDosMessages.ToDoNameExists);
        }
    }
}
