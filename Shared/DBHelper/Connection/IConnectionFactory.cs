using System;
using System.Data;

namespace DBHelper.Connection
{
    public interface IConnectionFactory
    {
        dynamic GetConnection { get; }

        
    }
}
