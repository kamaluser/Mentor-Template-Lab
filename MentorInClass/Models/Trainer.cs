namespace MentorInClass.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Branch { get; set; }
        public string ImgUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public List<Course> Courses { get; set; }
    }
}
