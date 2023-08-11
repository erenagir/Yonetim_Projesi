using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Common;

namespace X.Yönetim.Domain.Entities
{
    public class Statement:BaseEntity
    {
        public int PersonTypeId { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public PersonType PersonType { get; set; }
    }
}
