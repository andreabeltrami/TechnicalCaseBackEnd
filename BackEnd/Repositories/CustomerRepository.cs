using Amazon.Runtime.Internal;
using BackEnd.Models;
using BackEnd.Interfaces;
using BackEnd.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace BackEnd.Repositories
{
    public class CustomerRepository : IRepository<Customer>
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

        public Task<Customer> UpdateAsync(Customer input)
        {
            throw new NotImplementedException();
        }
    }
}
