using DarazClone.Core.Services.Dispatchers;
using DarazClone.Core.Services.Shared.Models;
using DarazClone.Products.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers.Products;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;
    public ProductController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpPost]
    public async Task<ApiResponseModel> AddTodo([FromBody] AddProductCommand command)
    {
        var res = await _commandDispatcher.DispatchAsync<AddProductCommand, ApiResponseModel>(command);

        if (!res.IsSuccess) {
            HttpContext.Response.StatusCode = res.HttpStatusCode;
        }

        return res;
    }

    [HttpGet]
    public async Task<ApiResponseModel> GetTodos()
    {
        var res = new ApiResponseModel();
        return res;
        // var res = await _queryDispatcher.DispatchAsync<GetAllTodosQuery, ApiResponseModel>();

        // if (!res.IsSuccess) {
        //     HttpContext.Response.StatusCode = res.HttpStatusCode;
        // }

        // return res;
    }
}

