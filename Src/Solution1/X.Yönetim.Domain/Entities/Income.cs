﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Common;

namespace X.Yönetim.Domain.Entities
{
    public class Income : AudiTableEntity
    {
        public int UserId { get; set; }
        public int BudgetId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }

        //navigation property
        public User User { get; set; }
        public Budget Budget { get; set; }
    }

}
