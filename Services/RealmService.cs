using Realms;
using System.Linq;

/// <summary>
/// Service class to manage Realm database operations for the "please." app.
/// Handles adding and retrieving data for MealTemplate and MealInstance objects.
/// </summary>
public class RealmService
{
    private readonly RealmConfiguration _config;

    /// <summary>
    /// Initializes the RealmService and sets up the Realm database configuration.
    /// </summary>
    public RealmService()
    {
        _config = new RealmConfiguration("please.realm") // Database file name
        {
            SchemaVersion = 1 // Define the schema version for migrations
        };
    }

    /// <summary>
    /// Gets a new Realm database instance for thread-safe operations.
    /// </summary>
    /// <returns>A new Realm database instance.</returns>
    private Realm GetRealmInstance() => Realm.GetInstance(_config);

    /// <summary>
    /// Adds a new MealTemplate to the database.
    /// </summary>
    /// <param name="meal">The MealTemplate object to add.</param>
    public void AddMeal(MealTemplate meal)
    {
        using var realm = GetRealmInstance();
        realm.Write(() =>
        {
            realm.Add(meal);
        });
    }

    /// <summary>
    /// Adds a new MealInstance to the database.
    /// </summary>
    /// <param name="mealInstance">The MealInstance object to add.</param>
    public void AddMealInstance(MealInstance mealInstance)
    {
        using var realm = GetRealmInstance();
        realm.Write(() =>
        {
            realm.Add(mealInstance);
        });
    }

    /// <summary>
    /// Retrieves all MealTemplate objects from the database.
    /// </summary>
    /// <returns>An IQueryable collection of MealTemplate objects.</returns>
    public IQueryable<MealTemplate> GetMeals()
    {
        var realm = GetRealmInstance();
        return realm.All<MealTemplate>();
    }

    /// <summary>
    /// Retrieves all MealInstance objects from the database.
    /// </summary>
    /// <returns>An IQueryable collection of MealInstance objects.</returns>
    public IQueryable<MealInstance> GetMealInstances()
    {
        var realm = GetRealmInstance();
        return realm.All<MealInstance>();
    }
}
