using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Common;

namespace X.Yönetim.Domain.Entities
{
    public class PersonType:AudiTableEntity
    {
        public string Name { get; set; }

        //Navigation Property
        public ICollection<Person> Persons { get; set; }
        public  ICollection<Statement> Statements { get; set; }
        
    }
}
