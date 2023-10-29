namespace CincoVertice.Food.Models
{
    public class NutritionFacts
    {
        public string ServingSizeName { get; set; } = string.Empty;
        public long ServingSizeUnit { get; set; }
        public decimal ServingSize_g { get; set; }
        public decimal Calories { get; set; }
        public decimal CaloriesFromFat { get; set; }
        public decimal TotalFat_g { get; set; }
        public decimal SaturatedFat_g { get; set; }
        public decimal Polyunsaturated_g { get; set; }
        public decimal Monounsaturated_g { get; set; }
        public decimal TransFat_g { get; set; }
        public decimal Cholesterol_mg { get; set; }
        public decimal Sodium_mg { get; set; }
        public decimal Potassium_mg { get; set; }
        public decimal TotalCarbohydrate_g { get; set; }
        public decimal DietaryFiber_g { get; set; }
        public decimal TotalSugars_g { get; set; }
        public decimal Protein_g { get; set; }
        public decimal VitaminA { get; set; }
        public decimal VitaminC { get; set; }
        public decimal Calcium { get; set; }
        public decimal Iron { get; set; }

        public void ClearValues()
        {
            ServingSize_g = 0;
            Calories = 0;
            CaloriesFromFat = 0;
            TotalFat_g = 0;
            SaturatedFat_g = 0;
            Polyunsaturated_g = 0;
            Monounsaturated_g = 0;
            TransFat_g = 0;
            Cholesterol_mg = 0;
            Sodium_mg = 0;
            Potassium_mg = 0;
            TotalCarbohydrate_g = 0;
            DietaryFiber_g = 0;
            TotalSugars_g = 0;
            Protein_g = 0;
            VitaminA = 0;
            VitaminC = 0;
            Calcium = 0;
            Iron = 0;
        }

        public static NutritionFacts operator +(NutritionFacts fact1, NutritionFacts fact2)
        {
            NutritionFacts nutritionFacts = new NutritionFacts()
            {
                ServingSize_g = fact1.ServingSize_g + fact2.ServingSize_g,
                Calories = fact1.Calories + fact2.Calories,
                CaloriesFromFat = fact1.CaloriesFromFat + fact2.CaloriesFromFat,
                TotalFat_g = fact1.TotalFat_g + fact2.TotalFat_g,
                SaturatedFat_g = fact1.SaturatedFat_g + fact2.SaturatedFat_g,
                Polyunsaturated_g = fact1.Polyunsaturated_g + fact2.Polyunsaturated_g,
                Monounsaturated_g = fact1.Monounsaturated_g + fact2.Monounsaturated_g,
                TransFat_g = fact1.TransFat_g + fact2.TransFat_g,
                Cholesterol_mg = fact1.Cholesterol_mg + fact2.Cholesterol_mg,
                Sodium_mg = fact1.Sodium_mg + fact2.Sodium_mg,
                Potassium_mg = fact1.Potassium_mg + fact2.Potassium_mg,
                TotalCarbohydrate_g = fact1.TotalCarbohydrate_g + fact2.TotalCarbohydrate_g,
                DietaryFiber_g = fact1.DietaryFiber_g + fact2.DietaryFiber_g,
                TotalSugars_g = fact1.TotalSugars_g + fact2.TotalSugars_g,
                Protein_g = fact1.Protein_g + fact2.Protein_g,
                VitaminA = fact1.VitaminA + fact2.VitaminA,
                VitaminC = fact1.VitaminC + fact2.VitaminC,
                Calcium = fact1.Calcium + fact2.Calcium,
                Iron = fact1.Iron + fact2.Iron,
            };

            return nutritionFacts;
        }

        public static NutritionFacts operator -(NutritionFacts fact1, NutritionFacts fact2)
        {
            NutritionFacts nutritionFacts = new NutritionFacts()
            {
                ServingSize_g = fact1.ServingSize_g - fact2.ServingSize_g,
                Calories = fact1.Calories - fact2.Calories,
                CaloriesFromFat = fact1.CaloriesFromFat - fact2.CaloriesFromFat,
                TotalFat_g = fact1.TotalFat_g - fact2.TotalFat_g,
                SaturatedFat_g = fact1.SaturatedFat_g - fact2.SaturatedFat_g,
                Polyunsaturated_g = fact1.Polyunsaturated_g - fact2.Polyunsaturated_g,
                Monounsaturated_g = fact1.Monounsaturated_g - fact2.Monounsaturated_g,
                TransFat_g = fact1.TransFat_g - fact2.TransFat_g,
                Cholesterol_mg = fact1.Cholesterol_mg - fact2.Cholesterol_mg,
                Sodium_mg = fact1.Sodium_mg - fact2.Sodium_mg,
                Potassium_mg = fact1.Potassium_mg - fact2.Potassium_mg,
                TotalCarbohydrate_g = fact1.TotalCarbohydrate_g - fact2.TotalCarbohydrate_g,
                DietaryFiber_g = fact1.DietaryFiber_g - fact2.DietaryFiber_g,
                TotalSugars_g = fact1.TotalSugars_g - fact2.TotalSugars_g,
                Protein_g = fact1.Protein_g - fact2.Protein_g,
                VitaminA = fact1.VitaminA - fact2.VitaminA,
                VitaminC = fact1.VitaminC - fact2.VitaminC,
                Calcium = fact1.Calcium - fact2.Calcium,
                Iron = fact1.Iron - fact2.Iron,
            };

            return nutritionFacts;
        }

        public static NutritionFacts operator *(NutritionFacts fact1, decimal times)
        {
            NutritionFacts nutritionFacts = new NutritionFacts()
            {
                ServingSize_g = fact1.ServingSize_g * times,
                Calories = fact1.Calories * times,
                CaloriesFromFat = fact1.CaloriesFromFat * times,
                TotalFat_g = fact1.TotalFat_g * times,
                SaturatedFat_g = fact1.SaturatedFat_g * times,
                Polyunsaturated_g = fact1.Polyunsaturated_g * times,
                Monounsaturated_g = fact1.Monounsaturated_g * times,
                TransFat_g = fact1.TransFat_g * times,
                Cholesterol_mg = fact1.Cholesterol_mg * times,
                Sodium_mg = fact1.Sodium_mg * times,
                Potassium_mg = fact1.Potassium_mg * times,
                TotalCarbohydrate_g = fact1.TotalCarbohydrate_g * times,
                DietaryFiber_g = fact1.DietaryFiber_g * times,
                TotalSugars_g = fact1.TotalSugars_g * times,
                Protein_g = fact1.Protein_g * times,
                VitaminA = fact1.VitaminA * times,
                VitaminC = fact1.VitaminC * times,
                Calcium = fact1.Calcium * times,
                Iron = fact1.Iron * times,
            };

            return nutritionFacts;
        }

        public static NutritionFacts operator /(NutritionFacts fact1, decimal times)
        {
            NutritionFacts nutritionFacts = new NutritionFacts()
            {
                ServingSize_g = fact1.ServingSize_g / times,
                Calories = fact1.Calories / times,
                CaloriesFromFat = fact1.CaloriesFromFat / times,
                TotalFat_g = fact1.TotalFat_g / times,
                SaturatedFat_g = fact1.SaturatedFat_g / times,
                Polyunsaturated_g = fact1.Polyunsaturated_g / times,
                Monounsaturated_g = fact1.Monounsaturated_g / times,
                TransFat_g = fact1.TransFat_g / times,
                Cholesterol_mg = fact1.Cholesterol_mg / times,
                Sodium_mg = fact1.Sodium_mg / times,
                Potassium_mg = fact1.Potassium_mg / times,
                TotalCarbohydrate_g = fact1.TotalCarbohydrate_g / times,
                DietaryFiber_g = fact1.DietaryFiber_g / times,
                TotalSugars_g = fact1.TotalSugars_g / times,
                Protein_g = fact1.Protein_g / times,
                VitaminA = fact1.VitaminA / times,
                VitaminC = fact1.VitaminC / times,
                Calcium = fact1.Calcium / times,
                Iron = fact1.Iron / times,
            };

            return nutritionFacts;
        }
    }
}
