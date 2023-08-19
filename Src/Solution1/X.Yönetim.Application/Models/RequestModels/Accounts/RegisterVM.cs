﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Entities;

namespace X.Yönetim.Application.Models.RequestModels.Accounts
{
    public class RegisterVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime Birtdate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }        
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
    }
}
