using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Yönetim.UI.Models.RequestModels.Expenses
{
    public class CreateExpenseVM
    {
        public int UserId { get; set; }
        public int BudgetId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
    }
}
