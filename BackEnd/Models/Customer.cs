using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BackEnd.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int SubscriptionState { get; set; }
        public List<Invoice>? Invoices { get; set; }
    }

    public enum SubsriptionState
    {
        New, 
        Active,
        Suspended
    }
}
