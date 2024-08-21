using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes;
        private List<Ingredient> ingredients;
        private List<string> steps;

        public MainWindow()
        {
            InitializeComponent();
            recipes = new List<Recipe>();
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        private void btnAddIngredients_Click(object sender, RoutedEventArgs e)
        {
            // Open a new IngredientsWindow to enter ingredient details
            var ingredientsWindow = new IngredientsWindow();
            ingredientsWindow.ShowDialog();

            // Add the entered ingredient to the list
            if (ingredientsWindow.DialogResult.HasValue && ingredientsWindow.DialogResult.Value)
            {
                var ingredient = ingredientsWindow.Ingredient;
                ingredients.Add(ingredient);
                lstIngredients.Items.Add(ingredient);
            }
        }

        private void btnAddSteps_Click(object sender, RoutedEventArgs e)
        {
            // Open a new StepsWindow to enter recipe steps
            var stepsWindow = new StepsWindow();
            stepsWindow.ShowDialog();

            // Add the entered steps to the list
            if (stepsWindow.DialogResult.HasValue && stepsWindow.DialogResult.Value)
            {
                var enteredSteps = stepsWindow.Steps;
                steps.AddRange(enteredSteps);
                foreach (var step in enteredSteps)
                {
                    lstSteps.Items.Add(step);
                }
            }
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Get the recipe details entered by the user
            string recipeName = txtRecipeName.Text;
            string recipeNumber = txtRecipeNumber.Text;

            // Create a new Recipe object
            Recipe recipe = new Recipe(recipeName, recipeNumber);
            recipe.Ingredients.AddRange(ingredients);
            recipe.Steps.AddRange(steps);

            // Add the recipe to the list and clear the input fields
            recipes.Add(recipe);
            txtRecipeName.Clear();
            txtRecipeNumber.Clear();
            lstIngredients.Items.Clear();
            lstSteps.Items.Clear();
            ingredients.Clear();
            steps.Clear();
        }

        private void btnFilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Open a new FilterWindow to enter filter criteria
            var filterWindow = new FilterWindow();
            filterWindow.ShowDialog();

            // Get the filter criteria entered by the user
            if (filterWindow.DialogResult.HasValue && filterWindow.DialogResult.Value)
            {
                int ingredientNumber = filterWindow.IngredientNumber;
                string foodGroup = filterWindow.FoodGroup;
                int maxCalories = filterWindow.MaxCalories;

                // Filter the recipes based on the criteria
                var filteredRecipes = recipes.Where(r =>
                    r.Ingredients.Any(i => i.Number == ingredientNumber) &&
                    (string.IsNullOrEmpty(foodGroup) || r.Ingredients.Any(i => i.FoodGroup == foodGroup)) &&
                    r.Ingredients.Sum(i => i.Calories) <= maxCalories
                ).ToList();

                // Display the filtered recipes
                lstFilteredRecipes.Items.Clear();
                foreach (var recipe in filteredRecipes.OrderBy(r => r.Name))
                {
                    lstFilteredRecipes.Items.Add(recipe);
                }
            }
        }
    }

    internal class Ingredient
    {
    }
}
