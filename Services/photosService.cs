using photosAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace photosAPI.Services
{
    public class PhotosService
    {
        private readonly IMongoCollection<photos> _photos;

        public PhotosService(IPhotosDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _photos = database.GetCollection<photos>(settings.PhotosCollectionName);
        }

        public List<photos> Get() =>
            _photos.Find(photo => true).ToList();

        public photos Get(string id) =>
            _photos.Find<photos>(photo => photo.Id == id).FirstOrDefault();

        public photos Create(photos photo)
        {
            _photos.InsertOne(photo);
            return photo;
        }

        public void Update(string id, photos photoIn) =>
            _photos.ReplaceOne(photo => photo.Id == id, photoIn);

        public void Remove(photos photoIn) =>
            _photos.DeleteOne(photo => photo.Id == photoIn.Id);

        public void Remove(string id) =>
            _photos.DeleteOne(photo => photo.Id == id);
    }
}