namespace TestingPlatform.Models
{
    public class Direction
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Group> Groups { get; set; }
    }
}