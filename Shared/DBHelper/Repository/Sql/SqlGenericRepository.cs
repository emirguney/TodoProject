using DBHelper.Connection;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDo.Shared.Dtos;
namespace DBHelper.Repository.Sql
{
    public class SqlGenericRepository 
    {
        readonly IConnectionFactory _connectionFactory;

        public SqlGenericRepository(IConnectionFactory connection)
        {
            _connectionFactory = connection;
        }
       
    }
}
