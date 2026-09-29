using Microsoft.AspNetCore.Mvc;

    namespace TestingPlatform.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllQuestions() => Ok("Список всех вопросов");

        [HttpGet("{id}")]
        public IActionResult GetQuestionById(int id)
        {
            if (id == 1) return Ok("Вопрос 1");
            return NotFound();
        }

        [HttpGet("by-test/{testId}")]
        public IActionResult GetQuestionsByTestId(int testId) => Ok($"Вопросы для теста {testId}");

        [HttpPost]
        public IActionResult CreateQuestion() => Created("/api/questions/1", "Вопрос создан");

        [HttpPut("{id}")]
        public IActionResult UpdateQuestion(int id) => NoContent();

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(int id) => NoContent();
    }

