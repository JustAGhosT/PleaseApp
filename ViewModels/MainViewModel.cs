using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Realms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PleaseApp.ViewModels
{
    /// <summary>
    /// MainViewModel serves as the ViewModel for the MainPage.
    /// It handles data binding and user interactions related to meals and meal instances.
    /// </summary>
    public partial class MainViewModel : ObservableObject
    {
        private readonly RealmService _realmService;

        /// <summary>
        /// Observable collection of MealTemplates for binding to the UI.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<MealTemplate> mealTemplates;

        /// <summary>
        /// Observable collection of MealInstances for binding to the UI.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<MealInstance> mealInstances;

        /// <summary>
        /// Initializes the MainViewModel with a RealmService for database operations.
        /// </summary>
        /// <param name="realmService">The RealmService instance for managing database interactions.</param>
        public MainViewModel(RealmService realmService)
        {
            _realmService = realmService;
            MealTemplates = new ObservableCollection<MealTemplate>();
            MealInstances = new ObservableCollection<MealInstance>();

            // Load data on initialization
            RefreshDataAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Loads meal templates and instances from the Realm database asynchronously.
        /// </summary>
        private async Task LoadDataAsync()
        {
            await Task.Run(() =>
            {
                // Load data in the background
                var templates = _realmService.GetMeals().ToList();
                var instances = _realmService.GetMealInstances().ToList();

                // Dispatch updates to the UI thread
                App.Current.Dispatcher.Dispatch(() =>
                {
                    // Update MealTemplates
                    MealTemplates.Clear();
                    foreach (var template in templates)
                    {
                        MealTemplates.Add(template);
                    }

                    // Update MealInstances
                    MealInstances.Clear();
                    foreach (var instance in instances)
                    {
                        MealInstances.Add(instance);
                    }
                });
            });
        }

        /// <summary>
        /// Command to add a new meal template.
        /// </summary>
        [RelayCommand]
        private void AddMealTemplate()
        {
            var newMeal = new MealTemplate
            {
                Id = MealTemplates.Count + 1,
                Name = "New Meal",
                Ingredients = "Ingredient 1, Ingredient 2",
                Calories = 0
            };

            _realmService.AddMeal(newMeal);
            MealTemplates.Add(newMeal);
        }

        /// <summary>
        /// Command to add a new meal instance.
        /// </summary>
        [RelayCommand]
        private void AddMealInstance(MealTemplate template)
        {
            if (template == null) return;

            var newMealInstance = new MealInstance
            {
                InstanceId = MealInstances.Count + 1,
                MealTemplate = template,
                Status = "Prepping",
                Timestamp = DateTimeOffset.UtcNow
            };

            _realmService.AddMealInstance(newMealInstance);
            MealInstances.Add(newMealInstance);
        }

        /// <summary>
        /// Command to refresh data asynchronously.
        /// </summary>
        [RelayCommand]
        private async Task RefreshDataAsync()
        {
            await LoadDataAsync();
        }
    }
}
