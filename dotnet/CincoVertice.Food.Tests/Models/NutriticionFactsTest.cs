using CincoVertice.Food.Models;
using Xunit;

namespace CincoVertice.Food.Tests.Models
{
    public class NutriticionFactsTest
    {
        [Fact]
        public void Add()
        {
            // Arrange
            var chickenBreast = new NutritionFacts()
            {
                ServingSize_g = 120,
                Calories = 211,
                CaloriesFromFat = 6.54M*9M,
                TotalFat_g = 6.54M,
                SaturatedFat_g = 1.212M,
                Polyunsaturated_g = 1.656M,
                Monounsaturated_g = 2.1M,
                TransFat_g = 0,
                Cholesterol_mg = 115.2M,
                Sodium_mg = 423.6M,
                Potassium_mg = 422.4M,
                TotalCarbohydrate_g = 0,
                DietaryFiber_g = 0,
                TotalSugars_g = 0,
                Protein_g = 35.544M,
                VitaminA = 0,
                VitaminC = 0,
                Calcium = 0.84M,
                Iron = 2.928M,
            };

            // Act
            var twoChickenBreast = chickenBreast + chickenBreast;

            // Assert
            Assert.Equal(chickenBreast.ServingSize_g * 2, twoChickenBreast.ServingSize_g);
            Assert.Equal(chickenBreast.Calories * 2, twoChickenBreast.Calories);
            Assert.Equal(chickenBreast.CaloriesFromFat * 2, twoChickenBreast.CaloriesFromFat);
            Assert.Equal(chickenBreast.TotalFat_g * 2, twoChickenBreast.TotalFat_g);
            Assert.Equal(chickenBreast.SaturatedFat_g * 2, twoChickenBreast.SaturatedFat_g);
            Assert.Equal(chickenBreast.Polyunsaturated_g * 2, twoChickenBreast.Polyunsaturated_g);
            Assert.Equal(chickenBreast.Monounsaturated_g * 2, twoChickenBreast.Monounsaturated_g);
            Assert.Equal(chickenBreast.Cholesterol_mg * 2, twoChickenBreast.Cholesterol_mg);
            Assert.Equal(chickenBreast.Sodium_mg * 2, twoChickenBreast.Sodium_mg);
            Assert.Equal(chickenBreast.Potassium_mg * 2, twoChickenBreast.Potassium_mg);
            Assert.Equal(chickenBreast.TotalCarbohydrate_g * 2, twoChickenBreast.TotalCarbohydrate_g);
            Assert.Equal(chickenBreast.DietaryFiber_g * 2, twoChickenBreast.DietaryFiber_g);
            Assert.Equal(chickenBreast.TotalSugars_g * 2, twoChickenBreast.TotalSugars_g);
            Assert.Equal(chickenBreast.Protein_g * 2, twoChickenBreast.Protein_g);
            Assert.Equal(chickenBreast.VitaminA * 2, twoChickenBreast.VitaminA);
            Assert.Equal(chickenBreast.VitaminC * 2, twoChickenBreast.VitaminC);
            Assert.Equal(chickenBreast.Calcium * 2, twoChickenBreast.Calcium);
            Assert.Equal(chickenBreast.Iron * 2, twoChickenBreast.Iron);
        }

        [Fact]
        public void Minus()
        {
            // Arrange
            var chickenBreast = new NutritionFacts()
            {
                ServingSize_g = 120,
                Calories = 211,
                CaloriesFromFat = 6.54M * 9M,
                TotalFat_g = 6.54M,
                SaturatedFat_g = 1.212M,
                Polyunsaturated_g = 1.656M,
                Monounsaturated_g = 2.1M,
                TransFat_g = 0,
                Cholesterol_mg = 115.2M,
                Sodium_mg = 423.6M,
                Potassium_mg = 422.4M,
                TotalCarbohydrate_g = 0,
                DietaryFiber_g = 0,
                TotalSugars_g = 0,
                Protein_g = 35.544M,
                VitaminA = 0,
                VitaminC = 0,
                Calcium = 0.84M,
                Iron = 2.928M,
            };

            // Act
            var twoChickenBreast = chickenBreast - chickenBreast;

            // Assert
            Assert.Equal(0, twoChickenBreast.ServingSize_g);
            Assert.Equal(0, twoChickenBreast.Calories);
            Assert.Equal(0, twoChickenBreast.CaloriesFromFat);
            Assert.Equal(0, twoChickenBreast.TotalFat_g);
            Assert.Equal(0, twoChickenBreast.SaturatedFat_g);
            Assert.Equal(0, twoChickenBreast.Polyunsaturated_g);
            Assert.Equal(0, twoChickenBreast.Monounsaturated_g);
            Assert.Equal(0, twoChickenBreast.Cholesterol_mg);
            Assert.Equal(0, twoChickenBreast.Sodium_mg);
            Assert.Equal(0, twoChickenBreast.Potassium_mg);
            Assert.Equal(0, twoChickenBreast.TotalCarbohydrate_g);
            Assert.Equal(0, twoChickenBreast.DietaryFiber_g);
            Assert.Equal(0, twoChickenBreast.TotalSugars_g);
            Assert.Equal(0, twoChickenBreast.Protein_g);
            Assert.Equal(0, twoChickenBreast.VitaminA);
            Assert.Equal(0, twoChickenBreast.VitaminC);
            Assert.Equal(0, twoChickenBreast.Calcium);
            Assert.Equal(0, twoChickenBreast.Iron);
        }
    }
}
