using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Yönetim.UI.Models.Dtos.Accounts
{
    public class TokenDto
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
        public Roles Role { get; set; }
    }
}
