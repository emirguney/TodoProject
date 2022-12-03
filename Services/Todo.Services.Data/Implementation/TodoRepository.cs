using DBHelper.Connection;
using DBHelper.Repository.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Services.Data.Interface;
using Todo.Services.Model.Model;

namespace Todo.Services.Data.Implementation
{
    public class TodoRepository : MongoGenericRepository<TodoModel>, ITodoRepository
    {
        public TodoRepository(IConnectionFactory connection) : base(connection)
        {
        }
    }
}
