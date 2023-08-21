using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Yönetim.Application.Models.RequestModels.Expenses
{
    public class UpdateExpenseVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BudgetId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
    }
}
