using CorePackages.Application.Requests;
using CorePackages.Application.Responses;
using CorePackages.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Features.Categories.Queries.GetList;
using ToDoList.Application.Features.Categories.Queries.GetListByDynamic;
namespace ToDoList.WebApi.Controllers;
public class CategoriesController : BaseController
{
    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCategoryQuery getListCategoryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCategoryByToDoListItemDto> response = await Mediator.Send(getListCategoryQuery);
        return Ok(response);
    }
    [HttpPost("GetList/ByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamicQuery = null)
    {
        GetListByDynamicCategoryQuery getListByDynamicCategoryQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
        GetListResponse<GetListByDynamicCategoryByToDoListItemDto> response = await Mediator.Send(getListByDynamicCategoryQuery);
        return Ok(response);
    }
}
