using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ax3.IMS.DataAccess.Mongo
{
    public interface IMongoContext : IDisposable
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        Task CreateCollectionAsync(string collectionName, CreateCollectionOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
        IMongoCollection<T> GetCollection<T>(string name);

    }
}
