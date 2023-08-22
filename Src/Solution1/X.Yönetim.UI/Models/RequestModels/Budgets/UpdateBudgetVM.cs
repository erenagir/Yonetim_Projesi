using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Yönetim.UI.Models.RequestModels.Budgets
{
    public class UpdateBudgetVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
      
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
