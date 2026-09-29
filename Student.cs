namespace TestingPlatform.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Phone { get; set; }

        public string VkProfileLink { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}