using MongoDB.Bson; //use mongodb in project
using MongoDB.Bson.Serialization.Attributes; //use mongodb in project

namespace GanaciAPI.Models
{ 
     [BsonIgnoreExtraElements]//Igone Extra Fields like(address)
    public class vehicleSale
    {
        [BsonId] //Map to mongodb
        [BsonRepresentation(BsonType.ObjectId)]//automatically convert mongo data type to .net data type
        public string Id { get; set; } = String.Empty;

        [BsonElement("vehicleBrand")]//define mongo db element name
        public string VehicleBrand { get; set; } = String.Empty;

        [BsonElement("vehicleModel")]
        public string VehicleModel { get; set; } = String.Empty;

        [BsonElement("vehicleSubcategory")]
        public string VehicleSubCategory { get; set; } = String.Empty;

        [BsonElement("vehicleCondition")]
        public string VehicleCondition { get; set; } = String.Empty;

        [BsonElement("manufacture")]
        public string Manufacture { get; set; } = String.Empty;

        [BsonElement("mileage")]
        public string Mileage { get; set; } = String.Empty;

        [BsonElement("price")]
        public string Price { get; set; } = String.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = String.Empty;

        [BsonElement("location")]
        public string Location { get; set; } = String.Empty;

        [BsonElement("contactNo")]
        public string ContactNo { get; set; } = String.Empty;
        
        [BsonElement("vehicleSaleAddDate")]
        public string VehicleSaleAddDate { get; set; } = String.Empty;

        [BsonElement("userEmail")]
        public string UserEmail { get; set; } = String.Empty;

        [BsonElement("engineCapacity")]
        public string EngineCapacity { get; set; } = String.Empty;

        [BsonElement("fuelType")]
        public string FuelType { get; set; } = String.Empty;

        [BsonElement("transmission")]
        public string Transmission { get; set; } = String.Empty;
    }
}
