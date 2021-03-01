namespace Ambedo.Models.Options
{
    public class DatabaseOptions
    {
        public const string KEY = "Database";
        public string ConnectionString { get; init; }
        public string ThootlesCollectionName { get; init; }
        public string DatabaseName { get; init; }
    }
}
