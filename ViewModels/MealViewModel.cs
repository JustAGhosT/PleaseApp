using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Realms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PleaseApp.ViewModels
{
    /// <summary>
    /// ViewModel for MealView, managing meal templates and specific meal instances.
    /// </summary>
    public partial class MealViewModel : ObservableObject
    {
        private readonly RealmService _realmService;

        /// <summary>
        /// Observable collection of meal templates for UI binding.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<MealTemplate> mealTemplates;

        /// <summary>
        /// Observable collection of meal instances for UI binding.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<MealInstance> mealInstances;

        /// <summary>
        /// Currently selected meal template.
        /// </summary>
        [ObservableProperty]
        private MealTemplate selectedMealTemplate;

        /// <summary>
        /// Search query for filtering meal templates.
        /// </summary>
        [ObservableProperty]
        private string searchQuery;

        public MealViewModel(RealmService realmService)
        {
            _realmService = realmService;
            MealTemplates = new ObservableCollection<MealTemplate>();
            MealInstances = new ObservableCollection<MealInstance>();

            // Load data when the ViewModel is initialized
            RefreshDataCommand.Execute(null);
        }

        /// <summary>
        /// Loads meal templates and instances from the database into observable collections.
        /// </summary>
        private async Task LoadDataAsync()
        {
            try
            {
                MealTemplates = await LoadCollectionAsync(_realmService.GetMeals);
                MealInstances = await LoadCollectionAsync(_realmService.GetMealInstances);
            }
            catch (Exception ex)
            {
                // Handle errors gracefully
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
        }

        private async Task<ObservableCollection<T>> LoadCollectionAsync<T>(Func<IEnumerable<T>> loadFunction)
        {
            return await Task.Run(() =>
            {
                var collection = new ObservableCollection<T>();
                var items = loadFunction();
                foreach (var item in items)
                {
                    collection.Add(item);
                }
                return collection;
            });
        }

        /// <summary>
        /// Command to refresh all data (meal templates and instances).
        /// </summary>
        [RelayCommand]
        public async Task RefreshData()
        {
            await LoadDataAsync();
        }

        /// <summary>
        /// Command to add a new meal template.
        /// </summary>
        [RelayCommand]
        public async Task AddMealTemplate()
        {
            try
            {
                if (string.IsNullOrEmpty(SearchQuery))
                {
                    Console.WriteLine("Invalid meal template data.");
                    return;
                }

                var newMeal = new MealTemplate
                {
                    Id = MealTemplates.Count + 1,
                    Name = "New Meal",
                    Ingredients = "Ingredient 1, Ingredient 2",
                    Calories = 100
                };

                _realmService.AddMeal(newMeal);
                MealTemplates.Add(newMeal);

                Console.WriteLine("Meal template added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding meal template: {ex.Message}");
            }
        }

        /// <summary>
        /// Command to delete a meal template.
        /// </summary>
        [RelayCommand]
        public async Task DeleteMealTemplate(MealTemplate template)
        {
            if (template == null) return;

            try
            {
                await Task.Run(() =>
                {
                    //TODO:
                    // _realmService.DeleteMeal(template);
                    MealTemplates.Remove(template);
                });

                Console.WriteLine("Meal template deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting meal template: {ex.Message}");
            }
        }

        /// <summary>
        /// Command to filter meal templates by search query.
        /// </summary>
        [RelayCommand]
        private void FilterMeals()
        {
            if (string.IsNullOrEmpty(SearchQuery))
            {
                RefreshDataCommand.Execute(null);
                return;
            }

            var filteredTemplates = _realmService.GetMeals()
                .Where(m => m.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase));
            MealTemplates.Clear();
            foreach (var template in filteredTemplates)
            {
                MealTemplates.Add(template);
            }
        }
    }
}
