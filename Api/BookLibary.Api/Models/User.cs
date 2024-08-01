using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookLibary.Api.Models
{
    public class User:IUser
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("UserName")]
        public string UserName { get; set; }
        [BsonElement("FullName")]
        public string FullName { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }


    }
}
