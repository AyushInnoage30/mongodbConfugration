using ConnectionMongoBd.Models.Entity;
using MongoDB.Driver;

namespace MongodbServices
{
    public class MOngoDBService
    {

        // _userContained hole data from MongoDB
        private readonly IMongoCollection<User> _userCollection;

        public MOngoDBService(IConfiguration config)
        {
            var client = new MongoClient(config["ConnectingStringDatabase:ConnectionString"]);
            var database = client.GetDatabase(config["ConnectingStringDatabase:DatabaseName"]);
            _userCollection = database.GetCollection<User>(config["ConnectingStringDatabase:UserCollection"]);
        }


        //For GetMethod
        public async Task <List<User>> GetUserAsync()
        {
            return await _userCollection.Find(user => true).ToListAsync();
        }

        public async Task CreatedUserAsync(User user)
        {
            await _userCollection.InsertOneAsync(user);
        }

    }
}
