namespace GanaciAPI.Models.DataBaseSettings
{
    public class UserDetailsDatabaseSettings : IUserDetailsDatabaseSettings
    {
        public String UserDetailsCollectionName { get; set; } = String.Empty;
        public String ConnectionString { get; set; } = String.Empty;
        public String DatabaseName { get; set; } = String.Empty;
    }
}
