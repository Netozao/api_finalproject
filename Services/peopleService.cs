using peopleAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace peopleAPI.Services
{
    public class PeopleService
    {
        private readonly IMongoCollection<People> _people;

        public PeopleService(IPeopleDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _people = database.GetCollection<People>(settings.PeopleCollectionName);
        }

        public List<People> Get() =>
            _people.Find(people => true).ToList();

        public People Get(string id) =>
            _people.Find<People>(people => people.Id == id).FirstOrDefault();

        public People Create(People people)
        {
            _people.InsertOne(people);
            return people;
        }

        public void Update(string id, People peopleIn) =>
            _people.ReplaceOne(people => people.Id == id, peopleIn);

        public void Remove(People peopleIn) =>
            _people.DeleteOne(people => people.Id == peopleIn.Id);

        public void Remove(string id) =>
            _people.DeleteOne(people => people.Id == id);
    }
}