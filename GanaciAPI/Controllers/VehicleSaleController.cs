using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GanaciAPI.Models.DataBaseSettings;
using MongoDB.Driver;
using GanaciAPI.Models;
using MongoDB.Bson;
using System.Drawing;

namespace GanaciAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleSaleController : ControllerBase
    {

        //Define Model
        private readonly IMongoCollection<vehicleSale> _vehicleSale;

        //create constructor
        public VehicleSaleController(IVehicleSaleDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName); //store database on variable
            _vehicleSale = database.GetCollection<vehicleSale>(settings.VehicleSaleCollectionName);//Call the collection
        }

        //Get all details in DB
        [HttpGet("GetAllRecordMongo")]
        [ActionName("GetAllRecordMongo")]
        public ActionResult<List<vehicleSale>> Get()
        {
            return _vehicleSale.Find(vehicleSale => true).ToList();
        }

        //Insert a VehicleSale
        [HttpPost("InsertVehicleSaleRecordMongo")]
        [ActionName("InsertVehicleSaleRecordMongo")]
        public dynamic InsertVehicleSaleRecordMongo([FromBody] vehicleSale lineValue)
        {
            _vehicleSale.InsertOne(lineValue);
            return lineValue;

            
        }


        //Upload Image
        [HttpPost("ImageSaveToFolder")]
        public async Task<IActionResult> ImageSaveToFolder(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file selected.");

            // Create a file stream to write the image data to
            string uniqueId = $"{DateTime.Now:yyyyMMddHHmmssffff}_{new Random().Next(10000, 99999)}";
            string filePath = @"H:\Ganacsi Project\Github\API\AfterSaveImages\" + uniqueId + ".jpg";

            // Load the image file
            Image myImage = Image.FromStream(file.OpenReadStream(), true, true);

            // Create a file stream to write the image data to
            FileStream fileStream = new FileStream(filePath, FileMode.Create);

            // Save the image to the file stream as a JPEG
            myImage.Save(fileStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            // Close the file stream
            fileStream.Close();

            Console.WriteLine(new { filename = uniqueId });

            return Ok(new { filename = uniqueId });

        }


    }
}
