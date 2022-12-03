using DBHelper.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Services.Data.Settings
{
    public class TodoDbSetting : IDbConfiguration
    {
        public string ConnectionString { get { return "mongodb://localhost:27017"; } }
        public string DatabaseName { get { return "TodoDB"; } }
    }
}
