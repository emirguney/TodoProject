using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ToDo.Shared.Dtos
{
    [BsonIgnoreExtraElements]
    public abstract  class AbstractEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public bool IsDelete { get; set; }
        public AbstractEntity()
        {
        }
    }
}
