using Microsoft.AspNetCore.Mvc;
using Todo.Services.Model.Dto;
using Todo.Services.Model.Model;
using Todo.Services.Service.Interface;
using Todo.Shared.Dtos;
using ToDo.Shared.Dtos;

namespace Todo.Services.TodoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController 
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        [HttpPost("InsertTodo")]
        public async Task<Response<string>> InsertTodo(CreateTodoModel todoModel)
        {
            return await _todoService.InsertTodo(todoModel);
        }
        [HttpGet("DeleteTodo")]
        public async Task<Response<NoContent>> DeleteTodo(string Id)
        {
            return await _todoService.DeleteTodo(Id);
        }
        [HttpGet("GetByTodoId")]
        public async Task<Response<TodoDto>> GetByTodoId(string Id)
        {
            return await _todoService.GetByTodoId(Id);
        }
        [HttpGet("GetAllTodo")]
        public async Task<Response<List<TodoDto>>> GetAllTodo()
        {
            return await _todoService.GetAllTodo();
        }
    }
}
