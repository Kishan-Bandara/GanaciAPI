namespace GanaciAPI.Models.DataBaseSettings
{
    public interface IVehicleSaleDatabaseSettings
    {
        String VehicleSaleCollectionName { get; set; }
        String ConnectionString { get; set; }
        String DatabaseName { get; set; }
    }
}
