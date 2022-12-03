using DBHelper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Services.Model.Model;

namespace Todo.Services.Data.Interface
{
    public interface ITodoRepository : IGenericRepository<TodoModel>
    {
    }
}
