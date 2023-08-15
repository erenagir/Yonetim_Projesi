using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Common;

namespace X.Yönetim.Domain.Entities
{
    public class Order:AudiTableEntity
    {
        public  int PersonId { get; set; }
        public string OrderDetail { get; set; }
       public OrderType OrderType { get; set; }
        public Person Person { get; set; }  
    }


    public enum OrderType
    {
        Income=1,//gelir
        Expense=2// gider

    }
}
