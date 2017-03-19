using MongoDB.Bson.Serialization.Attributes;

namespace KutuphaneAppWithIoC.Core.Models
{
    public class Book
    {
      
        [BsonId]
        public int Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
    }
}