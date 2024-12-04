using System.ComponentModel.DataAnnotations;

namespace Lab8.Models
{
    public class ImageModel
    {
        [Required]
        public IFormFile ImageFile { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
