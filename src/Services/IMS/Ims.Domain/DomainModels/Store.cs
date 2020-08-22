using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class Store : Entity
    {
        private string _name;
        private int _storeTypeId;
        public StoreType StoreType { get; private set; }

        public Store(string name, int storeTypeId)
        {
            _name = name;
            _storeTypeId = storeTypeId;
        }
    }
}
