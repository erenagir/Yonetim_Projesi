using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Common;

namespace X.Yönetim.Domain.Entities
{
    public class Account:AudiTableEntity
    {

        public int UserId { get; set; }
        public Roles Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string LastUserIp { get; set; }
        
       public User User { get; set; }
    }
    public enum Roles
    {
        Admin=1,
        User=2,
    }

}
