using System.Threading.Tasks;

namespace Ax3.IMS.DataAccess.Mongo
{
    public interface IMongoDbSeeder
    {
        Task SeedAsync();
    }
}
