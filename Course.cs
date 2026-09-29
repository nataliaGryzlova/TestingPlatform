namespace TestingPlatform.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Group> Groups { get; set; }
    }
}