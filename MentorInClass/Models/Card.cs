using System.ComponentModel.DataAnnotations.Schema;

namespace MentorInClass.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string BtnContext { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsAdvanced { get; set; }
        public List<CardFeature>? CardFeatures { get; set; }
        [NotMapped]
        public List<int>? FeatureIds { get; set; } = new List<int>();
    }
}
