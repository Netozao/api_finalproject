namespace peopleAPI.Models

{
    public class PeopleDatabaseSettings : IPeopleDatabaseSettings
    {
        public string PeopleCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPeopleDatabaseSettings
    {
        string PeopleCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}