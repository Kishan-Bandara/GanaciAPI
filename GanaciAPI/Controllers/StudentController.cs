using GanaciAPI.Models;
using GanaciAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GanaciAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        //inject student dervice
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<List<StudentTest>> Get()
        {
            return studentService.Get();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<StudentTest> Get(string id)
        {
            var student = studentService.Get(id);

            if (student == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            return student;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<StudentTest> Post([FromBody] StudentTest student)
        {
            studentService.Create(student);

            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] StudentTest student)
        {
            var existingStudent = studentService.Get(id);

            if (existingStudent == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            studentService.Update(id, student);

            return NoContent();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var student = studentService.Get(id);

            if (student == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            studentService.Remove(student.Id);

            return Ok($"Student with Id = {id} deleted");
        }
    }
}
