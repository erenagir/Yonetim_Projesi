using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Common;

namespace X.Yönetim.Domain.Entities
{
    public class User:AudiTableEntity
    {
        
       
        public string Name { get; set; }
        public string SurName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime Birtdate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        


        //Navigation Property

        public Account Account { get; set; }
        
        public ICollection<Income> Incomes { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Budget> Budgets { get; set; }
        public ICollection<Goal> Goals { get; set; }
        
        public ICollection<UserImage> UserImage { get; set; }
    }
    
    public enum Gender
    {
        Male=1,
        Female=2
    }
   
}
