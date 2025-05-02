using LMS.WebAPI.Entities;
using LMS.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        public IActionResult GetAllQuizzes()
        {
            return Ok(_quizService.GetAllQuizzes());
        }

        [HttpGet("{id}")]
        public IActionResult GetQuizById(int id)
        {
            var quiz = _quizService.GetQuizById(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return Ok(quiz);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddQuiz([FromBody] Quiz quiz)
        {
            _quizService.AddQuiz(quiz);
            return CreatedAtAction(nameof(GetQuizById), new { id = quiz.Id }, quiz);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateQuiz(int id, [FromBody] Quiz quiz)
        {
            if (id != quiz.Id)
            {
                return BadRequest();
            }
            _quizService.UpdateQuiz(quiz);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteQuiz(int id)
        {
            _quizService.DeleteQuiz(id);
            return NoContent();
        }
    }
}