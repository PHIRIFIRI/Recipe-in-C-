using System.Collections.Generic;
using System.Windows;

namespace RecipeApp
{
    public partial class StepsWindow : Window
    {
        public List<string> Steps { get; private set; }

        public StepsWindow()
        {
            InitializeComponent();
            Steps = new List<string>();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Get the number of steps entered by the user
            int numberOfSteps = int.Parse(txtNumberOfSteps.Text);

            // Open a new StepsInputDialog to enter the step descriptions
            var stepsInputDialog = new StepsInputDialog(numberOfSteps);
            stepsInputDialog.ShowDialog();

            // Add the entered step descriptions to the list
            if (stepsInputDialog.DialogResult.HasValue && stepsInputDialog.DialogResult.Value)
            {
                Steps = stepsInputDialog.StepDescriptions;
                DialogResult = true;
            }
        }
    }
}
