using GanaciAPI.Models;
using MongoDB.Driver;

namespace GanaciAPI.Services
{
    public class StudentService : IStudentService
    {
        private IMongoCollection<StudentTest> _students;

        //constructor
        public StudentService( IStudentStoreDatabaseSettings settings , IMongoClient mongoClient) {
            var database = mongoClient.GetDatabase(settings.DatabaseName); //store database on variable
            _students = database.GetCollection<StudentTest>(settings.StudentCoursesCollectionName);//Call the collection studentcoursetest
        }        
        public StudentTest Create(StudentTest student) //Insert one students
        {
            _students.InsertOne(student);
            return student;
        }

        public List<StudentTest> Get()//Get one student
        {
            return _students.Find(student => true).ToList();
        }

        public StudentTest Get(string id)//get single student by id
        {
            return _students.Find(student => student.Id == id).FirstOrDefault();
        }

        public void Remove(string id)//remove by id
        {
            _students.DeleteOne(student => student.Id == id);
        }

        public void Update(string id, StudentTest student)//update by ID
        {
            _students.ReplaceOne(student => student.Id == id, student);
        }



    }
}
