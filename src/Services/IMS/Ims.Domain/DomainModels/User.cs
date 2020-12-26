using System;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class User : Entity
    {
        public string UserName { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Mobile { get; private set; }
        public string Email { get; private set; }
        public Guid? FamilyId { get; private set; }
        public Family Family { get; private set; }
        public Guid? LocalCurrencyId { get; private set; }
        public InvestmentTool LocalCurrency { get; set; }

        public User(Guid id, string userName, string name, string surname, Guid? familyId, string mobile,
            string email, Guid? localCurrencyId) : base(id)
        {
            UserName = userName;
            Name = name;
            Surname = surname;
            FamilyId = familyId;
            Mobile = mobile;
            Email = email;
            LocalCurrencyId = localCurrencyId;
        }

        public void SetLocalCurrencyId(Guid investmentToolId)
        {
            LocalCurrencyId = investmentToolId;
        }
    }
}
