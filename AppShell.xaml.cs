using PleaseApp.Views;

namespace PleaseApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Centralized route registration for programmatic navigation
        Routing.RegisterRoute(Routes.MealDetails, typeof(MealView));
        
        /// Example: Passing parameters to a route
        /// await Shell.Current.GoToAsync($"{Routes.MealDetails}?mealId=1&category=breakfast");
    }
}

/// <summary>
/// Centralized route definitions to avoid hardcoding strings.
/// </summary>
public static class Routes
{
    public const string MainPage = "main";
    public const string MealDetails = "meal/details";
}
