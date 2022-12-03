using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToDo.Shared.Dtos;

namespace DBHelper.Repository
{
    public interface IGenericRepository<T> 
    {
        Result GetById(string id);
        int Count();
        Result GetAllWithDeleted();
        Result GetAll();
        Result GetAll(int pageSize, int pageNumber, Expression<Func<T, bool>> predicate = null);
        IEnumerable<T> GetAll(string tableName);
        T GetByExpression(string searchQuery);
        IEnumerable<T> GetListByExpression(string searchQuery);
        IEnumerable<T> Page(int pageSize, int pageNumber, int count);
        dynamic GetMultipleQuery(string query);
        Result Insert(T entity);
        Result Update(T entity);
        Result BulkUpdate(List<T> entityList);
        Result DeleteById(T entity);
        void DeleteCompletely(string id);
        int Delete(T entity);
        void Delete(string id);
        int Delete(int[] id);
        bool Delete(List<T> entities);
        bool Delete(params T[] entities);
        void ExecuteScript(string script);
        T GetByLangId(int langId, int id);
        Result GetListByExpression(Expression<Func<T, bool>> predicate = null);
        Result GetListByExpressionWithDeleted(Expression<Func<T, bool>> predicate = null);

    }
}
