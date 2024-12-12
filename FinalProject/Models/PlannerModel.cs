

namespace FinalProject.Models
{
    public class PlannerModel
    {
        public List<TaskModel> Tasks { get; set; } = new();
        public TimeZoneInfo TimeZone { get; set; }
    }
}
