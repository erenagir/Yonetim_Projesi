using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Common;

namespace X.Yönetim.Domain.Entities
{
    public class Transaction:AudiTableEntity
    {   
        public string PersonId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; }
        public Person Person { get; set; }
    }
    public enum TransactionType
    {
        Income,
        Expense
    }

}
