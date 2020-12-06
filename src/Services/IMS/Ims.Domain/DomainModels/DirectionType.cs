using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class DirectionType : Enumeration
    {
        public static DirectionType Positive = new DirectionType(1, "+", "Artı");
        public static DirectionType Negative = new DirectionType(2, "-", "Eksi");

        public DirectionType(int enumId, string code, string name)
            : base(enumId, code, name)
        {

        }
    }
}
