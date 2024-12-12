using FinalProject.DataObjects;

namespace FinalProject.Models
{
    public class TaskModel
    {
        public int ID { get; set; }
        public DateTime DueDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string TaskStatus { get; set; }
    }
}
