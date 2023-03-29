using GanaciAPI.Models;

namespace GanaciAPI.Services
{
    public interface IStudentService
    {
        List<StudentTest> Get(); //Return List of all student
        StudentTest Get(string id); //Return single student by id
        StudentTest Create(StudentTest student); // Crate a new student and return that new created student
        void Update(string id, StudentTest student); // Update by Id
        void Remove(string id); // remove by ID
    }
}
