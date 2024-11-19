using PleaseApp.ViewModels;

namespace PleaseApp.Views
{
    [QueryProperty(nameof(Parameter), "parameter")]
    public partial class MealView : ContentPage
    {
        public string Parameter { get; set; }

        public MealView(MealViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is MealViewModel viewModel)
            {
                viewModel.RefreshData();
                if (!string.IsNullOrEmpty(Parameter))
                {
                    Console.WriteLine($"Navigation parameter received: {Parameter}");
                }
            }
        }
    }
}
