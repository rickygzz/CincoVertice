namespace CincoVertice.Food.Models
{
    public class Food
    {
        public long Id { get; set; }
        
        public string Name { get; set; } = string.Empty;

        public List<string> AlternateName { get; set; } = new();

        public NutritionFacts NutritionFacts { get; set; } = new();
    }
}
