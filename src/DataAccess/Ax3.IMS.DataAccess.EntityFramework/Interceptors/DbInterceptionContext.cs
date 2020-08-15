using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace Ax3.IMS.DataAccess.EntityFramework.Interceptors
{
    public class DbInterceptionContext
    {
        public DbContext DbContext { get; set; }

        public IEnumerable<EntityEntry> Entries { get; set; }

        public ILookup<EntityState, EntityEntry> EntriesByState { get; set; }
        public string UserId { get; set; }
    }
}