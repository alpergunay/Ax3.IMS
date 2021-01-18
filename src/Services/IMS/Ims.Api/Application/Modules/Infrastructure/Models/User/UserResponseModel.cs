using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ims.Api.Application.Modules.Infrastructure.Models.User
{
    public class UserResponseModel : BaseResponseModel
    {
        public string UserName { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Mobile { get; private set; }
        public string Email { get; private set; }
        public Guid? FamilyId { get; private set; }
        public string FamilyName { get; set; }
        public Guid? LocalCurrencyId { get; private set; }
        public string LocalCurrencyName { get; set; }
        public Guid? CountryId { get; private set; }
        public string CountryName { get; set; }
    }
}
