using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Services.Model.Dto
{
    public class CreateTodoModel
    {
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string MainTodoId { get; set; }
    }
}
