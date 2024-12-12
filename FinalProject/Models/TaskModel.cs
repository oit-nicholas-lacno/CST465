using FinalProject.DataObjects;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class TaskModel
    {
        [Required(ErrorMessage = "Task needs a due date")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Task needs a error message")]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }


        public string TaskStatus { get; set; }
    }
}
