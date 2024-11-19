using Realms;
using System;

/// <summary>
/// Represents a specific occurrence of a meal, such as when it is consumed, prepped, or added to a shopping list.
/// </summary>
public class MealInstance : RealmObject
{
    /// <summary>
    /// Unique identifier for the specific meal instance.
    /// </summary>
    [PrimaryKey]
    public int InstanceId { get; set; }

    /// <summary>
    /// Reference to the template of the meal associated with this instance.
    /// </summary>
    public MealTemplate MealTemplate { get; set; }

    /// <summary>
    /// The current status of the meal instance (e.g., "Consumed", "Prepping", "Shopping").
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Timestamp indicating when this instance of the meal was created or updated.
    /// </summary>
    public DateTimeOffset Timestamp { get; set; }
}
