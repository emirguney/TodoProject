using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DBHelper.Connection;
using ToDo.Shared.Dtos;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DBHelper.Repository.Mongo
{
    public class MongoGenericRepository<T> : IGenericRepository<T> where T : AbstractEntity
    {
        readonly IConnectionFactory _connectionFactory;

        public MongoGenericRepository(IConnectionFactory connection)
        {
            _connectionFactory = connection;
        }

        public Result BulkUpdate(List<T> entityList)
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
        public void DeleteCompletely(string id)
        {
            var database = _connectionFactory.GetConnection as MongoDB.Driver.IMongoDatabase;
            var collectionName = string.Format("{0}Collection", typeof(T).Name);


            var data = database.GetCollection<T>(collectionName).DeleteOne(x => x.Id == id);
        }

        public void Delete(string id)
        {
            var database = _connectionFactory.GetConnection as MongoDB.Driver.IMongoDatabase;
            var collectionName = string.Format("{0}Collection", typeof(T).Name);

            T entity = database.GetCollection<T>(collectionName).Find(x => x.Id == id).FirstOrDefault();
            entity.IsDelete = true;
            database.GetCollection<T>(collectionName).ReplaceOne(u => u.Id == entity.Id, entity);
        }
        public Result DeleteById(T entity)
        {
            var database = _connectionFactory.GetConnection as MongoDB.Driver.IMongoDatabase;
            var collectionName = string.Format("{0}Collection", typeof(T).Name);

            entity.IsDelete = true;
            var data = database.GetCollection<T>(collectionName).ReplaceOne(u => u.Id == entity.Id, entity);
            var dbResponse = new Result();
            dbResponse.IsSuccess = true;
            dbResponse.Data = data;

            return dbResponse;
        }

        public int Delete(int[] id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<T> entities)
        {
            throw new NotImplementedException();
        }

        public bool Delete(params T[] entities)
        {
            throw new NotImplementedException();
        }

        public void ExecuteScript(string script)
        {
            throw new NotImplementedException();
        }

        public Result GetAll()
        {
            var database = _connectionFactory.GetConnection as MongoDB.Driver.IMongoDatabase;
            var collectionName = string.Format("{0}Collection", typeof(T).Name);

            var data = database.GetCollection<T>(collectionName).Find(x => x.IsDelete != true).ToList();

            var dbResponse = new Result();
            dbResponse.IsSuccess = true;
            dbResponse.Data = data;

            return dbResponse;
        }
        public Result GetAllWithDeleted()
        {
            var database = _connectionFactory.GetConnection as MongoDB.Driver.IMongoDatabase;
            var collectionName = string.Format("{0}Collection", typeof(T).Name);

            var data = database.GetCollection<T>(collectionName).AsQueryable().ToList();

            var dbResponse = new Result();
            dbResponse.IsSuccess = true;
            dbResponse.Data = data;

            return dbResponse;
        }


        public IEnumerable<T> GetAll(string tableName)
        {
            throw new NotImplementedException();
        }

        public T GetByExpression(string searchQuery)
        {
            var filter = BsonDocument.Parse(searchQuery);
            var database = _connectionFactory.GetConnection as MongoDB.Driver.IMongoDatabase;
            var collectionName = string.Format("{0}Collection", typeof(T).Name);

            var data = database.GetCollection<T>(collectionName).Find(filter).FirstOrDefault();
            return data;
        }

        public Result GetById(string id)
        {
            var database = _connectionFactory.GetConnection as MongoDB.Driver.IMongoDatabase;
            var collectionName = string.Format("{0}Collection", typeof(T).Name);


            var data = database.GetCollection<T>(collectionName).Find(x => x.Id == id).FirstOrDefault();

            var dbResponse = new Result();
            dbResponse.IsSuccess = true;
            dbResponse.Data = data;

            return dbResponse;
        }
        public T GetByLangId(int langId, int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetListByExpression(string searchQuery)
        {
            var filter = BsonDocument.Parse(searchQuery);
            var database = _connectionFactory.GetConnection as IMongoDatabase;
            var collectionName = string.Format("{0}Collection", typeof(T).Name);

            var data = database.GetCollection<T>(collectionName).Find(filter).ToList();
            return data;
        }

        public Result GetListByExpression(Expression<Func<T, bool>> predicate = null)
        {
            var database = _connectionFactory.GetConnection as MongoDB.Driver.IMongoDatabase;
            var collectionName = string.Format("{0}Collection", typeof(T).Name);

            var dbResponse = new Result();

            if (predicate == null)
            {
                var data = database.GetCollection<T>(collectionName).Find(x => x.IsDelete != true).ToList();
                dbResponse.IsSuccess = true;
                dbResponse.Data = data;
                return dbResponse;
            }
            else
            {
                var data = (database.GetCollection<T>(collectionName).Find(x => x.IsDelete != true).ToList()).Where(predicate.Compile());
                dbResponse.IsSuccess = true;
                dbResponse.Data = data.ToList();
                return dbResponse;
            }
            


       
        }
        public Result GetListByExpressionWithDeleted(Expression<Func<T, bool>> predicate = null)
        {
            var database = _connectionFactory.GetConnection as MongoDB.Driver.IMongoDatabase;
            var collectionName = string.Format("{0}Collection", typeof(T).Name);

            var dbResponse = new Result();

            if (predicate == null)
            {
                var data = database.GetCollection<T>(collectionName).Find(x => x.Id != null).ToList();
                dbResponse.IsSuccess = true;
                dbResponse.Data = data;
                return dbResponse;
            }
            else
            {
                var data = (database.GetCollection<T>(collectionName).Find(x => x.Id != null).ToList()).Where(predicate.Compile());
                dbResponse.IsSuccess = true;
                dbResponse.Data = data.ToList();
                return dbResponse;
            }
        }

        public dynamic GetMultipleQuery(string query)
        {
            throw new NotImplementedException();
        }

        public Result Insert(T entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            var database = _connectionFactory.GetConnection as MongoDB.Driver.IMongoDatabase;
            var collectionName = string.Format("{0}Collection", typeof(T).Name);


            database.GetCollection<T>(collectionName).InsertOne(entity);

            var dbResponse = new Result();
            dbResponse.IsSuccess = true;
            dbResponse.Data = entity.Id;

            return dbResponse;


        }

        public  Result GetAll(int pageSize, int pageNumber, Expression<Func<T, bool>> predicate = null)
        {
            var database = _connectionFactory.GetConnection as MongoDB.Driver.IMongoDatabase;
            var collectionName = string.Format("{0}Collection", typeof(T).Name);

            var collection = database.GetCollection<T>(collectionName);

            var data =  collection.Find(predicate)
                 .Skip((pageNumber - 1) * pageSize)
                 .Limit(pageSize)
                 .ToList();

            var dbResponse = new Result();
            dbResponse.IsSuccess = true;
            dbResponse.Data = data;

            return dbResponse;
        }



        public IEnumerable<T> Page(int pageSize, int pageNumber, int count)
        {

            throw new NotImplementedException();
        }

        public Result Update(T entity)
        {
            var database = _connectionFactory.GetConnection as MongoDB.Driver.IMongoDatabase;
            var collectionName = string.Format("{0}Collection", typeof(T).Name);
            var data = database.GetCollection<T>(collectionName).ReplaceOne(u => u.Id == entity.Id, entity);
            var dbResponse = new Result();
            dbResponse.IsSuccess = true;
            dbResponse.Data = data;

            return dbResponse;
        }
    }
}
