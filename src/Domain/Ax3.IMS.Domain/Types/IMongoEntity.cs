using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Ax3.IMS.Domain.Types
{
    public interface IMongoEntity
    {
        /// <summary>
        /// create date
        /// </summary>
        DateTime CreatedOn { get; }

        /// <summary>
        /// id in string format
        /// </summary>
        [BsonId]
        string Id { get; set; }

        /// <summary>
        /// modify date
        /// </summary>
        DateTime ModifiedOn { get; }

        /// <summary>
        /// id in objectId format
        /// </summary>
        [BsonIgnore]
        ObjectId ObjectId { get; }
    }
}
