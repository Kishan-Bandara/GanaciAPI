using GanaciAPI.Models;

namespace GanaciAPI.Services
{
    public interface ISignUpService
    {
        List<userDetails> Get(); //Return List of all student
        userDetails Get(string id); //Return single student by id
        userDetails Create(userDetails user); // Crate a new student and return that new created student
        void Update(string id, userDetails user); // Update by Id
        void Remove(string id); // remove by ID
        userDetails InsertUserDetailRecord(userDetails userDetails); //New Method
        userDetails GetByNameUserDetailRecordMongo(string firstName); //Get By UserName
        userDetails GetByEmailUserDetailRecordMongo(string Email); //Get By UserName
        void UploadImage();//Upload Image

    }
}
