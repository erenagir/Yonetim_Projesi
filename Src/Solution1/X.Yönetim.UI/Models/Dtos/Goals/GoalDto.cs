namespace X.Yönetim.UI.Models.Dtos.Goals
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
