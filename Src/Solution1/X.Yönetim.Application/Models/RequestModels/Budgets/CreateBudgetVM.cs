﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Yönetim.Application.Models.RequestModels.Budgets
{
    public class CreateBudgetVM
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
