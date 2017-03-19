using MongoDB.Bson;

namespace KutuphaneAppWithIoC.Core.Models
{
    public class ProcessLog
    {
        public ObjectId Id { get; set; }
        public string Borrower { get; set; }
        public int Isbn { get; set; }
    }
}