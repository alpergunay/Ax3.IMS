using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class StoreBranch : Entity
    {
        public string Name { get; private set; }
        public Guid StoreId { get; private set; }
        public Store Store { get; private set; }

        public StoreBranch(string name, Guid storeId)
        {
            Name = name;
            StoreId = storeId;
        }
        public void Update(string name, Guid storeId)
        {
            this.Name = name;
            this.StoreId = storeId;
        }
    }
}
