using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shopping.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public byte[] Photo { get; set; }
    }
}
