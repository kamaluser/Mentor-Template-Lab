using NuGet.DependencyResolver;

namespace MentorInClass.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
    }
}
