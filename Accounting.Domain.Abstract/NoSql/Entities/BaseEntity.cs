using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace Accounting.Domain.Abstract.NoSql.Entities
{
    public abstract class BaseEntity
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public bool IsDeleted { get; set; }

        protected BaseEntity()
        {
            _id = ObjectId.GenerateNewId();
        }
    }
}
