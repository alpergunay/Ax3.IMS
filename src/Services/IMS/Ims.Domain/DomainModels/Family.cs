using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class Family : Entity
    {
        public string Name { get; private set; }

        public Family(string name)
        {
            Name = name;
        }
    }
}
