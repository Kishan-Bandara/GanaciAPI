using GanaciAPI.Models;
using GanaciAPI.Models.DataBaseSettings;
using MongoDB.Driver;
using MongoDB.Bson;

namespace GanaciAPI.Services
{
    public class SignUpService : ISignUpService
    {

        private readonly IMongoCollection<userDetails> _signUp;
        public SignUpService(IUserDetailsDatabaseSettings settings , IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName); //store database on variable
            _signUp = database.GetCollection<userDetails>(settings.UserDetailsCollectionName);//Call the collection
        }

        public userDetails Create(userDetails userDetails) //Insert one students
        {
            _signUp.InsertOne(userDetails);
            return userDetails;
        }

        public List<userDetails> Get() //Get user Details
        {
            return _signUp.Find(userDetails => true).ToList();
        }

        public userDetails Get(string id) // Get Singel User by ID
        {
            return _signUp.Find(userDetails => userDetails.Id == id).FirstOrDefault();
        }

        public userDetails GetName(string firstName) // Get Singel User by User First Name
        {
            return _signUp.Find(userDetails => userDetails.FirstName == firstName).FirstOrDefault();
        }

        public void Remove(string id) // remove BY ID
        {
            _signUp.DeleteOne(userDetails => userDetails.Id == id);
        }

        public void Update(string id, userDetails user) // Update by ID
        {
            _signUp.ReplaceOne(user => user.Id == id, user);
        }

        public userDetails InsertUserDetailRecord(userDetails userD) //Insert one students
        {
            _signUp.InsertOne(userD);
            return userD;
        }

        public userDetails GetByNameUserDetailRecordMongo(string firstName) //Search one user by Name
        {
            return _signUp.Find(userDetails => userDetails.FirstName == firstName).FirstOrDefault();
        }

        public userDetails GetByEmailUserDetailRecordMongo(string Email) //Search one user by Email
        {
            return _signUp.Find(userDetails => userDetails.Email == Email).FirstOrDefault();
        }

        public void UploadImage() //Search one user by Email
        {
            //var file = Request.Form.Files[0];
            //var form = Request.ReadFormAsync().Result;
            //var file = form.Files[0];
            //using (var memoryStream = new MemoryStream())
            //{
            //    file.CopyTo(memoryStream);
            //    var imageData = memoryStream.ToArray();
            //    var bsonDocument = new BsonDocument
            //{
            //    { "imageData", imageData }
            //};
            //    _signUp.InsertOne(bsonDocument);
            //}
            //return Ok();
        }


    }
}
