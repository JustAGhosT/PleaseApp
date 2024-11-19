using Realms;
using System;

/// <summary>
/// Represents a reusable template for a meal, including its name, ingredients, and nutritional details.
/// </summary>
public class MealTemplate : RealmObject
{
    /// <summary>
    /// Unique identifier for the meal template.
    /// </summary>
    [PrimaryKey]
    public int Id { get; set; }

    /// <summary>
    /// The name of the meal (e.g., "Oatmeal Breakfast").
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Ingredients required for the meal.
    /// </summary>
    public string Ingredients { get; set; }

    /// <summary>
    /// Total calories for the meal.
    /// </summary>
    public int Calories { get; set; }
}
