using System;
using System.Threading.Tasks;

namespace Ax3.IMS.DataAccess.Mongo
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
