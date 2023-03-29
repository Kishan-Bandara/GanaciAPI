namespace GanaciAPI.Models
{
    public class StudentStoreDatabaseSettings : IStudentStoreDatabaseSettings
    {
        public String StudentCoursesCollectionName { get; set; } = String.Empty;
        public String ConnectionString { get; set; } = String.Empty;
        public String DatabaseName { get; set; } = String.Empty;
    }
}
