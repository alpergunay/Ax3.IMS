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
        public Guid FamilyId { get; private set; }
        public Family Family { get; private set; }

        public User(string userName, string name, string surname, Guid familyId, string mobile, string email)
        {
            UserName = userName;
            Name = name;
            Surname = surname;
            FamilyId = familyId;
            Mobile = mobile;
            Email = email;
        }
    }
}
