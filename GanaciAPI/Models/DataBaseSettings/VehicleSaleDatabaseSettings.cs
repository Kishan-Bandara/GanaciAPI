namespace GanaciAPI.Models.DataBaseSettings
{
    public class VehicleSaleDatabaseSettings : IVehicleSaleDatabaseSettings
    {
        public String VehicleSaleCollectionName { get; set; } = String.Empty;
        public String ConnectionString { get; set; } = String.Empty;
        public String DatabaseName { get; set; } = String.Empty;
    }
}
