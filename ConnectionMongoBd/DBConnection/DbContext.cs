using ConnectionMongoBd.Models.Entity;
using MongoDB.Driver;

namespace MongodbServices
{
    public class MongoDBService
    {
        private readonly IMongoDatabase _database;

        public MongoDBService(IConfiguration config)
        {
            var client = new MongoClient(config["ConnectingStringDatabase:ConnectionString"]);
            _database = client.GetDatabase(config["ConnectingStringDatabase:DatabaseName"]);
        }

        // Generic method to get any collection

        //IMongoCollection<T> comes from MongoDB.Driver namespace.
        //GetCollection is custome name 
        // This function point reference of collection and we perfome crud operation on this collection
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }

        // For User Collection
        

        

        // Example for another collection (e.g., Orders)
        //public async Task<List<Order>> GetOrdersAsync()
        //{
        //    var orders = GetCollection<Order>("OrderCollection");
        //    return await orders.Find(order => true).ToListAsync();
        //}

        //public async Task CreateOrderAsync(Order order)
        //{
        //    var orders = GetCollection<Order>("OrderCollection");
        //    await orders.InsertOneAsync(order);
        //}
    }
}
