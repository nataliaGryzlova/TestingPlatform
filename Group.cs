namespace TestingPlatform.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DirectionId { get; set; }
        public Direction Direction { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public List<Student> Students { get; set; }
    }
}
