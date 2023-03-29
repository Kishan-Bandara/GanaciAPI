namespace GanaciAPI.Models.DataBaseSettings
{
    public interface IUserDetailsDatabaseSettings
    {
        String UserDetailsCollectionName { get; set; }
        String ConnectionString { get; set; }
        String DatabaseName { get; set; }
    }
}
