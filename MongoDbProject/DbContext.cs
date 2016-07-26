using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbProject
{
    public class DbContext
    {
        public IMongoDatabase db { get; set; }
        public DbContext(string database)
        {
            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient(settings);

            db = client.GetDatabase(database);
        }
    }
}
