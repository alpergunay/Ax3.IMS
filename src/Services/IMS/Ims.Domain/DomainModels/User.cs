using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;
using Microsoft.AspNetCore.Identity;

namespace Ims.Domain.DomainModels
{
    public class User : Entity
    {
        private string _name;
        private string _surname;
        private string _mobile;
        private string _email;

        public User(string name, string surname, string mobile, string email)
        {
            _name = name;
            _surname = surname;
            _mobile = mobile;
            _email = email;
        }
    }
}
