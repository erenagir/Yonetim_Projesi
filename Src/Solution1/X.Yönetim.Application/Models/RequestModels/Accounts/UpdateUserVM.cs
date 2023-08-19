using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Entities;

namespace X.Yönetim.Application.Models.RequestModels.Accounts
{
    public class UpdateUserVM
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime Birtdate { get; set; }
       
      
    }
}
