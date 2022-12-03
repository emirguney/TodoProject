using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Services.Model.Dto;
using Todo.Services.Model.Model;
using Todo.Shared.Dtos;
using ToDo.Shared.Dtos;

namespace Todo.Services.Service.Interface
{
    public interface ITodoService
    {
        Task<Response<string>> InsertTodo(CreateTodoModel todoModel);
        Task<Response<TodoDto>> GetByTodoId(string Id);
        Task<Response<List<TodoDto>>> GetAllTodo();
        Task<Response<NoContent>> DeleteTodo(string Id);
    }
}
