using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Yönetim.Application.Models.Dtos.Accounts
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
