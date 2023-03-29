using MongoDB.Bson; //use mongodb in project
using MongoDB.Bson.Serialization.Attributes; //use mongodb in project

namespace GanaciAPI.Models
{
    [BsonIgnoreExtraElements]//Igone Extra Fields like(address)
    public class userDetails
    {
        [BsonId] //Map to mongodb
        [BsonRepresentation(BsonType.ObjectId)]//automatically convert mongo data type to .net data type
        public string Id { get; set; } = String.Empty;

        [BsonElement("firstName")]//define mongo db element name
        public string FirstName { get; set; } = String.Empty;

        [BsonElement("lastName")]
        public string LastName { get; set; } = String.Empty;

        [BsonElement("nic")]
        public string Nic { get; set; } 

        [BsonElement("phoneNo")]
        public string PhoneNo { get; set; } = String.Empty;

        [BsonElement("occupation")]
        public string Occupation { get; set; } 

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("profilePicture")]
        public string ProfilePicture { get; set; }
    }
}
