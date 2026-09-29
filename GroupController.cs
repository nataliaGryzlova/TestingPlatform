using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Data;
using TestingPlatform.Models;

namespace TestingPlatform.Controllers;

public class GroupDto
{
    public string Name { get; set; } = "";
    public int DirectionId { get; set; }
    public int CourseId { get; set; }
    public int ProjectId { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class GroupsController : ControllerBase
{
    private readonly AppDbContext _db;

    public GroupsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult GetAllGroups()
    {
        var groups = _db.Groups
            .Select(g => new
            {
                g.Id,
                g.Name,
                g.DirectionId,
                Direction = g.Direction.Name,
                g.CourseId,
                Course = g.Course.Name,
                g.ProjectId,
                Project = g.Project.Name
            })
            .ToList();

        return Ok(groups);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetGroupById(int id)
    {
        if (id <= 0)
            return BadRequest("Некорректный id");

        var group = _db.Groups
            .Where(g => g.Id == id)
            .Select(g => new
            {
                g.Id,
                g.Name,
                g.DirectionId,
                Direction = g.Direction.Name,
                g.CourseId,
                Course = g.Course.Name,
                g.ProjectId,
                Project = g.Project.Name
            })
            .FirstOrDefault();

        if (group is null)
            return NotFound();

        return Ok(group);
    }

    [HttpPost]
    public IActionResult CreateGroup([FromBody] GroupDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            return BadRequest("Название группы не может быть пустым");

        if (!_db.Directions.Any(d => d.Id == dto.DirectionId))
            return BadRequest("Направление не найдено");

        if (!_db.Courses.Any(c => c.Id == dto.CourseId))
            return BadRequest("Курс не найден");

        if (!_db.Projects.Any(p => p.Id == dto.ProjectId))
            return BadRequest("Проект не найден");

        if (_db.Groups.Any(g => g.Name == dto.Name))
            return Conflict("Группа с таким названием уже существует");

        var group = new Group
        {
            Name = dto.Name,
            DirectionId = dto.DirectionId,
            CourseId = dto.CourseId,
            ProjectId = dto.ProjectId
        };

        _db.Groups.Add(group);
        _db.SaveChanges();

        return Created($"/api/groups/{group.Id}", new { group.Id, group.Name });
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateGroup([FromRoute] int id, [FromBody] GroupDto dto)
    {
        if (id <= 0)
            return BadRequest("Некорректный id");

        var group = _db.Groups.FirstOrDefault(g => g.Id == id);

        if (group is null)
            return NotFound();

        if (string.IsNullOrWhiteSpace(dto.Name))
            return BadRequest("Название группы не может быть пустым");

        if (!_db.Directions.Any(d => d.Id == dto.DirectionId))
            return BadRequest("Направление не найдено");

        if (!_db.Courses.Any(c => c.Id == dto.CourseId))
            return BadRequest("Курс не найден");

        if (!_db.Projects.Any(p => p.Id == dto.ProjectId))
            return BadRequest("Проект не найден");

        if (_db.Groups.Any(g => g.Name == dto.Name && g.Id != id))
            return Conflict("Группа с таким названием уже существует");

        group.Name = dto.Name;
        group.DirectionId = dto.DirectionId;
        group.CourseId = dto.CourseId;
        group.ProjectId = dto.ProjectId;

        _db.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteGroup(int id)
    {
        var group = _db.Groups.Find(id);

        if (group is null)
            return NotFound();

        _db.Groups.Remove(group);
        _db.SaveChanges();

        return NoContent();
    }
}