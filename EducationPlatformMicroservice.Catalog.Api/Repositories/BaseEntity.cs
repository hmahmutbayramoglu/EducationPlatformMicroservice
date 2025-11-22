using MongoDB.Bson.Serialization.Attributes;

namespace EducationPlatformMicroservice.Catalog.Api.Repositories
{
    public class BaseEntity
    {
        //snowflake id uniq ve indexlemesi kolay üretir
        [BsonElement("_id")]
        public Guid Id { get; set; }


    }
}
