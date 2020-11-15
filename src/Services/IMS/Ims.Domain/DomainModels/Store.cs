using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class Store : Entity
    {
        public string Name { get; private set; }
        public int StoreTypeId { get; private set; }
        public StoreType StoreType { get; private set; }

        public Store(string name, int storeTypeId)
        {
            Name = name;
            StoreTypeId = storeTypeId;
        }

        public void Update(string name, int storeTypeId)
        {
            this.Name = name;
            this.StoreTypeId = storeTypeId;
        }
    }
}
