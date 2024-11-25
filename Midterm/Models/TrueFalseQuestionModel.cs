using System.ComponentModel.DataAnnotations;
namespace Midterm;

public class TrueFalseQuestionModel : TestQuestionModel
{
    [Required]
    [RegularExpression(@"true|false", ErrorMessage = "Must be True or False")]
    public override string Answer{get;set;}
}