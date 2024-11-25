using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
namespace Midterm;

//TODO:  Is something missing here? 
[Route("Midterm")]
public class MidtermExamController : Controller
{
    private readonly MidtermExam _Exam;
    private readonly IConfiguration _Config;
    
    public MidtermExamController(IConfiguration conf, IOptions<MidtermExam> exam)
    {
        _Exam = exam.Value;
    }
    [Route("")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [Route("TakeTest")]
    [HttpGet]
    public IActionResult TakeTest()
    {
        List<TestQuestionModel> questionModels = GetQuestionModels();
        return View(questionModels);
    }
    [Route("SubmitTest")]
    [HttpPost]
    public IActionResult TakeTest(List<TestQuestionModel> model)
    {
        List<TestQuestionModel> questionModels = GetQuestionModels();
        //TODO: At this point you will only have the raw answers in the model.  Questions did not get posted back.
        //You will need to get the questions again from GetQuestionModels(), then set the answer values on the retrieved list by
        //  matching the two lists based on ID
        if (model.Count == questionModels.Count)
        {
            for (int i = 0; i < questionModels.Count; ++i)
            {
                questionModels[i].Answer = model[i].Answer;
            }
        }

        if(!ModelState.IsValid)
        {
            return View(questionModels);
        }

        //TODO: Change the below so that it loads the DisplayResults view, passing in the model
        return View("DisplayResults", questionModels);
        
    }
    private List<TestQuestionModel> GetQuestionModels()
    {
        List<TestQuestionModel> questionModels = new List<TestQuestionModel>();
        foreach(var question in _Exam.Questions)
        {
            if(question.QuestionType == "TrueFalseQuestion")
            {
                TrueFalseQuestionModel tfQuestion = new TrueFalseQuestionModel();
                tfQuestion.ID = question.ID;
                tfQuestion.Question = question.Question;
                questionModels.Add(tfQuestion);
            }
            else if(question.QuestionType == "ShortAnswerQuestion")
            {
                ShortAnswerQuestionModel saQuestion = new();
                saQuestion.ID = question.ID;
                saQuestion.Question = question.Question;
                questionModels.Add(saQuestion);
            }
            else if (question.QuestionType == "LongAnswerQuestion")
            {
                LongAnswerQuestionModel laQuestion = new();
                laQuestion.ID = question.ID;
                laQuestion.Question = question.Question;
                questionModels.Add(laQuestion);
            }
            else if (question.QuestionType == "MultipleChoiceQuestion")
            {
                MultipleChoiceQuestionModel mcQuestion = new();
                mcQuestion.ID = question.ID;
                mcQuestion.Question = question.Question;
                mcQuestion.Choices = question.Choices;
                questionModels.Add(mcQuestion);
            }
        }
        return questionModels;
    }
}