using Microsoft.AspNetCore.Mvc;
using ToDo.Services.Model;


namespace ToDoProject.Controllers
{
    public class TodoController
    {
        [HttpPost("InsertTodo")]
        public async Task<Response<TodoModel>> GetGoWellTogether(string foodId)
        {
            List<string> data = new List<string>();
            data.Add(foodId);
            return await _foodService.GetGoWellTogether(data);
        }
    }
}
