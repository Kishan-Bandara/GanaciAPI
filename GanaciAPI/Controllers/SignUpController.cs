using GanaciAPI.Models;
using GanaciAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GanaciAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpService signupService;

        public SignUpController(ISignUpService signupService) { 
            this.signupService = signupService;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<List<userDetails>> Get()
        {
            return signupService.Get();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<userDetails> Get(string id)
        {
            var signUp = signupService.Get(id);

            if (signUp == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            return signUp;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{firstName}")]
        public ActionResult<userDetails> GetName(string firstName)
        {
            var signUp = signupService.Get(firstName);

            if (signUp == null)
            {
                return NotFound($"Student with Name = {firstName} not found");
            }

            return signUp;
        }




        //

        // POST api/<StudentsController>
        [HttpPost]
        // [ActionName("InsertUserDetailRecord")]
        public ActionResult<userDetails> Post([FromBody] userDetails userD)
        {
            signupService.Create(userD);

            return CreatedAtAction(nameof(Get), new { id = userD.Id }, userD);
        }


        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] userDetails userD)
        {
            var existingStudent = signupService.Get(id);

            if (existingStudent == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            signupService.Update(id, userD);

            return NoContent();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var userD = signupService.Get(id);

            if (userD == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            signupService.Remove(userD.Id);

            return Ok($"Student with Id = {id} deleted");
        }


        //

        //Insert a User
        [HttpPost("InsertUserDetailRecordMongo")]
        [ActionName("InsertUserDetailRecordMongo")]
        public dynamic InsertUserDetailRecordMongo([FromBody] userDetails lineValue)
        {
            signupService.InsertUserDetailRecord(lineValue);

            return CreatedAtAction(nameof(Get), new { id = lineValue.Id }, lineValue);
        }

        //Search User By Name
        [HttpGet("GetByNameUserDetailRecordMongo")]
        [ActionName("GetByNameUserDetailRecordMongo")]
        public dynamic GetByNameUserDetailRecordMongo(string firstName)
        {
            var userDetails = signupService.GetByNameUserDetailRecordMongo(firstName);

            if (userDetails == null)
            {
                return NotFound($"User first with Id = {firstName} not found");
            }

            return userDetails;
        }

        //Search User By Email
        [HttpGet("GetByEmailUserDetailRecordMongo")]
        [ActionName("GetByEmailUserDetailRecordMongo")]
        public dynamic GetByEmailUserDetailRecordMongo(string Email)
        {
            var userDetails = signupService.GetByEmailUserDetailRecordMongo(Email);

            //if (userDetails == null)
            //{
            //    return NotFound($"User Email with Email = {Email} not found");
            //}

            return userDetails;
        }

        //Upload Image
        //[HttpPost("UploadImage")]
        //[ActionName("UploadImage")]
        //public IActionResult UploadImage()
        //{

        //    signupService.InsertUserDetailRecord(lineValue);

        //    return CreatedAtAction(nameof(Get), new { id = lineValue.Id }, lineValue);

        //    var file = Request.Form.Files[0];
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        file.CopyTo(memoryStream);
        //        var imageData = memoryStream.ToArray();
        //        var bsonDocument = new BsonDocument
        //    {
        //        { "imageData", imageData }
        //    };
        //        _imagesCollection.InsertOne(bsonDocument);
        //    }
        //    return Ok();
        //}


    }
}
