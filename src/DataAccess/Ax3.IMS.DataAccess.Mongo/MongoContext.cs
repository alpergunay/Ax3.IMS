using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ax3.IMS.DataAccess.Mongo
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoClient MongoClient { get; set; }
        private readonly List<Func<Task>> _commands;

        public MongoContext(IMongoDatabase database, MongoClient mongoClient)
        {
            Database = database;
            MongoClient = mongoClient;
            // Every command will be stored and it'll be processed at SaveChanges
            _commands = new List<Func<Task>>();
        }
        public async Task<int> SaveChanges()
        {
            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();

                var commandTasks = _commands.Select(c => c()); 

                await Task.WhenAll(commandTasks);

                await Session.CommitTransactionAsync();
            }

            return _commands.Count;
        }       

        public async Task CreateCollectionAsync(string collectionName, CreateCollectionOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Database.CreateCollectionAsync(collectionName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {            
            return Database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }        
    }
}
