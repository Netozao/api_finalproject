namespace photosAPI.Models

{
    public class PhotosDatabaseSettings : IPhotosDatabaseSettings
    {
        public string PhotosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPhotosDatabaseSettings
    {
        string PhotosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}