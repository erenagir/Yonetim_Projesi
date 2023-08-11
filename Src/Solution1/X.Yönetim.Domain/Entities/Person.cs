using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Common;

namespace X.Yönetim.Domain.Entities
{
    public class Person:AudiTableEntity
    {
        public int PersonTypeId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime Birtdate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public decimal Salary { get; set; }
       
        //Navigation Property
        public PersonType PersonType { get; set; }



    }
    
    public enum Gender
    {
        Male=1,
        Female=2
    }
}
