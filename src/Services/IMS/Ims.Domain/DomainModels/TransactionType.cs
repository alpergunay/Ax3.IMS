using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class TransactionType : Entity
    {
        private string _code;
        private string _description;
        private int _directionTypeId;
        public DirectionType DirectionType { get; set; }

        public TransactionType(string code, string description, int directionTypeId)
        {
            _code = code;
            _description = description;
            _directionTypeId = directionTypeId;
        }
    }
}
