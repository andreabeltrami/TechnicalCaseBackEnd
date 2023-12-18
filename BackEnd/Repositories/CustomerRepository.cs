using BackEnd.Interfaces;
using BackEnd.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BackEnd.Repositories
{
    public class CustomerRepository : IRepository<Customer, string>
    {
        private readonly IMongoCollection<Customer> _customersCollection;

        public CustomerRepository(
            IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _customersCollection = mongoDatabase.GetCollection<Customer>(
                databaseSettings.Value.CollectionName);
        }


        public async Task<Customer> CreateAsync(Customer input)
        {
            input.Id = ObjectId.GenerateNewId().ToString();
            input.Invoices.ForEach(x => x.Id = ObjectId.GenerateNewId().ToString());
            await _customersCollection.InsertOneAsync(input);
            return input;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            List<Customer> result = await _customersCollection.Find(x => true).ToListAsync();
            return result;
        }

        public async Task<Customer> GetByKey(string key)
        {
            Customer result = await _customersCollection.Find(x => x.Id == key).FirstOrDefaultAsync();
            return result;
        }

        public Task<Customer> UpdateAsync(Customer input)
        {
            throw new NotImplementedException();
        }
    }
}
