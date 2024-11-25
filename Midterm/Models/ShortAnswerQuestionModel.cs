using System.ComponentModel.DataAnnotations;

namespace Midterm
{
    public class ShortAnswerQuestionModel : TestQuestionModel
    {
        [Required]
        [MaxLength(100)]
        public override string Answer { get; set; }
    }
}
