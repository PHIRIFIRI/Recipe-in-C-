using System.Windows;

namespace RecipeApp
{
    public partial class IngredientsWindow : Window
    {
        public Ingredient Ingredient { get; private set; }

        public IngredientsWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Get the ingredient details entered by the user
            int ingredientNumber = int.Parse(txtIngredientNumber.Text);
            string ingredientName = txtIngredientName.Text;
            double quantity = double.Parse(txtQuantity.Text);
            string unitOfMeasurement = txtUnitOfMeasurement.Text;
            int totalCalories = int.Parse(txtTotalCalories.Text);

            // Create a new Ingredient object
            Ingredient = new Ingredient(ingredientNumber, ingredientName, quantity, unitOfMeasurement, totalCalories);

            // Close the window
            DialogResult = true;
        }
    }
}
