using System;

using System.Collections.Generic;
using DBHelper.Connection;
using System.Linq;
using System.Linq.Expressions;
using ToDo.Shared.Dtos;

namespace DBHelper.Repository.Redis
{
    public class RedisGenericRepository<T> : IGenericRepository<T> where T : AbstractEntity
    {
        public RedisGenericRepository()
        {
        }
        public Result DeleteById(T entity)
        {
            throw new NotImplementedException();
        }
        public Result BulkUpdate(System.Collections.Generic.List<T> entityList)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int[] id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(System.Collections.Generic.List<T> entities)
        {
            throw new NotImplementedException();
        }

        public bool Delete(params T[] entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompletely(string id)
        {
            throw new NotImplementedException();
        }

        public void ExecuteScript(string script)
        {
            throw new NotImplementedException();
        }

        public Result GetAll()
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<T> GetAll(string tableName)
        {
            throw new NotImplementedException();
        }

        public Result GetAll(int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public Result GetAll(int pageSize, int pageNumber, Expression<Func<T, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Result GetAllWithDeleted()
        {
            throw new NotImplementedException();
        }

        public T GetByExpression(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public Result GetById(string id)
        {
            throw new NotImplementedException();
        }

        public T GetByLangId(int langId, int id)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<T> GetListByExpression(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetListByExpression(Expression<Func<T, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public dynamic GetMultipleQuery(string query)
        {
            throw new NotImplementedException();
        }

        public Result Insert(T entity)
        {
            throw new NotImplementedException();
        }
        
        public System.Collections.Generic.IEnumerable<T> Page(int pageSize, int pageNumber, int count)
        {
            throw new NotImplementedException();
        }

        public Result Update(T entity)
        {
            throw new NotImplementedException();
        }
        
        Result IGenericRepository<T>.GetListByExpression(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        Result IGenericRepository<T>.GetListByExpressionWithDeleted(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
