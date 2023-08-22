using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Entities;

namespace X.Yönetim.Application.Models.Dtos.Accounts
{
    public class UserDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime Birtdate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }

    }
}
