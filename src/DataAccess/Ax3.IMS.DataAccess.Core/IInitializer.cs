using System.Threading.Tasks;

namespace Ax3.IMS.DataAccess.Core
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}
