using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Entities;

namespace X.Yönetim.Domain.Services.Abstraction
{
    public class ILoggedService
    {
        int? UserId { get; }
        string Username { get; }
        public string Email { get; }

    }
}

