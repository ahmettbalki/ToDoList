using CorePackages.Application.Requests;
using CorePackages.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Features.ToDos.Commands.Create;
using ToDoList.Application.Features.ToDos.Commands.Update;
using ToDoList.Application.Features.ToDos.Queries.GetById;
using ToDoList.Application.Features.ToDos.Queries.GetList;
namespace ToDoList.WebApi.Controllers;
public class ToDosController : BaseController
{
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateToDoCommand createToDoCommand)
    {
        CreatedToDoResponse response = await Mediator.Send(createToDoCommand);
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListToDoQuery getListToDoQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListToDoListItemDto> response = await Mediator.Send(getListToDoQuery);
        return Ok(response);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdToDoQuery getByIdToDoQuery = new() { Id = id };
        GetByIdToDoResponse response = await Mediator.Send(getByIdToDoQuery);
        return Ok(response);
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateToDoCommand updateToDoCommand)
    {
        UpdatedToDoResponse response = await Mediator.Send(updateToDoCommand);
        return Ok(response);
    }
}