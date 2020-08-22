using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class StoreBranch : Entity
    {
        private string _name;
        private Guid _storeId;
        public Store Store { get; private set; }

        public StoreBranch(string name, Guid storeId)
        {
            _name = name;
            _storeId = storeId;
        }
    }
}
