using System;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class User : Entity
    {
        private string _name;
        private string _surname;
        private string _mobile;
        private string _email;
        private Guid _familyId;
        public Family Family { get; set; }

        public User(string name, string surname, Guid familyId, string mobile, string email)
        {
            _name = name;
            _surname = surname;
            _familyId = familyId;
            _mobile = mobile;
            _email = email;
        }
    }
}
