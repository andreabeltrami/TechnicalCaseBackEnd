using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BackEnd.Models
{
    public class Invoice
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
    }
}
