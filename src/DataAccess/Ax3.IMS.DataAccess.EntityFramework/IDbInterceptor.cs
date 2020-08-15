using Ax3.IMS.DataAccess.EntityFramework.Interceptors;

namespace Ax3.IMS.DataAccess.EntityFramework
{
    public interface IDbInterceptor
    {
        void Before(DbInterceptionContext context);

        void After(DbInterceptionContext context);
    }
}