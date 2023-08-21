using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Domain.Entities;

namespace X.Yönetim.Application.Models.Dtos.Goals
{
    public class GoalDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal TargetAmount { get; set; }
        public DateTime TargetDate { get; set; }
        public string Description { get; set; }

       
    }
}
