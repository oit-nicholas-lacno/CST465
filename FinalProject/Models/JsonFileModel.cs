using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class JsonFileModel
    {
        [Required(ErrorMessage = "JSON file required")]
        public IFormFile FileData { get; set; }
    }
}
