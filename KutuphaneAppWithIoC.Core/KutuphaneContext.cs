using System.Transactions;
using KutuphaneAppWithIoC.Core.Models;
using MongoDB.Driver;

namespace KutuphaneAppWithIoC.Core
{
    public class KutuphaneContext
    {
        public TransactionScope Transaction { get; set; }
        private MongoDatabase _db;

        public KutuphaneContext()
        {
            var client = new MongoClient();
            var server = client.GetServer();
            _db = server.GetDatabase("kutuphane");
        }

        public MongoCollection<Book> Books
        {
            get { return _db.GetCollection<Book>("Book"); }
        }
        public MongoCollection<ProcessLog> ProcessLogs
        {
            get { return _db.GetCollection<ProcessLog>("ProcessLog"); }
        }
    }
}