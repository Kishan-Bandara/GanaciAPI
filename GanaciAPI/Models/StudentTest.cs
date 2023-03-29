using MongoDB.Bson; //use mongodb in project
using MongoDB.Bson.Serialization.Attributes; //use mongodb in project

namespace GanaciAPI.Models
{
    [BsonIgnoreExtraElements]//Igone Extra Fields like(address)
    public class StudentTest
    {
        [BsonId] //Map to mongodb
        [BsonRepresentation(BsonType.ObjectId)]//automatically convert mongo data type to .net data type
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]//define mongo db element name
        public string Name { get; set; } = String.Empty;

        [BsonElement("graduated")]
        public bool IsGraduated { get; set; }

        [BsonElement("courses")]
        public string[]? Courses { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; } = String.Empty;

        [BsonElement("age")]
        public int Age { get; set; }
    }
}
