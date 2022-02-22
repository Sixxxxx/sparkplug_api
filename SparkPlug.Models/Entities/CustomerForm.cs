using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SparkPlug.Models.Entities
{
    public class CustomerForm
    {
        public CustomerForm()
        {
            DateCreated = DateTime.Now;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = default!;
        public string CustomerName { get; set; } = default!;
        public string CustomerEmail { get; set; } = default!;
        public string CustomerMessage { get; set; } = default!;
        public DateTime DateCreated { get; set; } = default!;
    }
}
