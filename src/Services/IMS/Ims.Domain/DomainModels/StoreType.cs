using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class StoreType : Enumeration
    {
        public static StoreType Bank = new StoreType(1, "BA", "Bank");
        public static StoreType Home = new StoreType(2, "HO", "Home");
        public static StoreType Loan = new StoreType(3, "LO", "Loan");
        public static StoreType StockBroker = new StoreType(4, "SB", "Stock Broker");

        public StoreType(int enumId, string code, string name)
            : base(enumId, code, name)
        {

        }
    }
}
