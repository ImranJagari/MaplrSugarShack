using MongoDB.Driver;

namespace MaplrSugarShack.Server.Services
{
	public sealed class MongoService
	{
		private IMongoDatabase _database;
		public MongoService(IConfiguration configuration)
        {
            var client = new MongoClient(MongoClientSettings.FromConnectionString(configuration.GetConnectionString("Mongo")));
            GenerateDatabase(client);
        }

        private void GenerateDatabase(MongoClient client)
        {
            var names = client.ListDatabaseNames().ToList();
            const string DatabaseName = "maplr";
            if (!names.Contains(DatabaseName))
                throw new Exception($"The database '{DatabaseName}' doesn't exist !");

            _database = client.GetDatabase(DatabaseName);
        }

        public IMongoDatabase Database => _database;
	}
}
