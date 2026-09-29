using Microsoft.AspNetCore.Mvc;

namespace homework.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllAnswers()
        => Ok("Список всех ответов");

    [HttpGet("{id}")]
    public IActionResult GetAnswerById(int id)
    {
        if (id == 1)
            return Ok("Ответ 1");

        return NotFound();
    }

    [HttpPost]
    public IActionResult CreateAnswer()
        => Created("/api/answers/1", "Ответ сохранён");

    [HttpPut("{id}")]
    public IActionResult UpdateAnswer(int id)
        => NoContent();

    [HttpDelete("{id}")]
    public IActionResult DeleteAnswer(int id)
        => NoContent();
}