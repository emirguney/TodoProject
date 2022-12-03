using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Services.Data.Interface;

namespace Todo.Services.Service.Core
{
    public interface IUnitOfWork
    {
        public ITodoRepository Todo { get; set; }
    }
}
