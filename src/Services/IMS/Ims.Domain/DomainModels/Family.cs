using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class Family : Entity
    {
        private string _name;
        private Guid _userId;
        public User User { get; set; }

        public Family(string name, Guid userId)
        {
            _name = name;
            _userId = userId;
        }
    }
}
