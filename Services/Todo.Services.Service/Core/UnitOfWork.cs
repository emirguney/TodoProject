using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Services.Data.Interface;

namespace Todo.Services.Service.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ITodoRepository todo)
        {
            Todo = todo;
        }
        public ITodoRepository Todo { get; set; }
    }
}
