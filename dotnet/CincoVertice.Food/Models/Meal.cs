namespace CincoVertice.Food.Models
{
    public class Meal
    {
        NutritionFacts NutritionFacts { get; set; } = new();

        private readonly List<Food> _foods = new();

        public Meal(string servingSize)
        {
            NutritionFacts.ServingSizeName = servingSize;
        }

        public void AddFood(Food food)
        {
            _foods.Add(food);

            NutritionFacts += food.NutritionFacts;
        }

        public void ClearFood()
        {
            _foods.Clear();

            NutritionFacts.ClearValues();
        }

        public void SetFoods(List<Food> foods)
        {
            NutritionFacts.ClearValues();
            foreach (var food in foods)
            {
                NutritionFacts += food.NutritionFacts;
            }
        }
    }
}
