using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeApp
{
    public partial class StepsInputDialog : Window
    {
        public List<Step> Steps { get; private set; }
        public List<string> StepDescriptions => Steps.Select(s => s.Description).ToList();

        public StepsInputDialog(int numberOfSteps)
        {
            InitializeComponent();
            Steps = new List<Step>();

            // Generate step objects with default descriptions
            for (int i = 0; i < numberOfSteps; i++)
            {
                Steps.Add(new Step(i + 1, ""));
            }

            // Set the data context to the steps list
            itemsControl.ItemsSource = Steps;
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            // Close the window
            DialogResult = true;
        }
    }
}
