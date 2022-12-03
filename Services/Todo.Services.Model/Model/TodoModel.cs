using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Shared.Dtos;

namespace Todo.Services.Model.Model
{
    public class TodoModel : BaseModel
    {
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string MainTodoId { get; set; }


    }
}
