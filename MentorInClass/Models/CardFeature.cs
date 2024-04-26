namespace MentorInClass.Models
{
    public class CardFeature
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
        public Card Card { get; set; }
    }
}
