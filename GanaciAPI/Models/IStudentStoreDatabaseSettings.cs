namespace GanaciAPI.Models
{
    //  //define connection string to mongodb
    public interface IStudentStoreDatabaseSettings
    {
        String StudentCoursesCollectionName { get; set; }
        String ConnectionString { get; set; }
        String DatabaseName { get; set; }
    }
}
