using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestingPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllTests() => Ok("Список тестов");

        [HttpGet("{id}")]
        public IActionResult GetTestById(int id)
        {
            if (id == 1) return Ok("Тест 1");
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateTest() => Created("/api/tests/1", "Создан тест с ID=1");

        [HttpPut("{id}")]
        public IActionResult UpdateTest(int id) => NoContent();

        [HttpDelete("{id}")]
        public IActionResult DeleteTest(int id) => NoContent();
    }

}
