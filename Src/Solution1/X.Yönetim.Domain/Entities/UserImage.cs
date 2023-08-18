using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Common;

namespace X.Yönetim.Domain.Entities
{
    public class UserImage:BaseEntity
    {
        public int UserId { get; set; }
        public string Path { get; set; }
        public User User { get; set; }
    }
}
