
# **Folder Structure**

The following structure organizes the project to separate UI, data, and logic layers, ensuring modularity and scalability.

```
please-app/
├── Platforms/              # Platform-specific files (iOS, Android, Windows, macOS)
├── Resources/              # App resources like images, fonts, and icons
├── Models/                 # Realm models (e.g., Meals, Exercises)
│   ├── MealTemplate.cs
│   ├── MealInstance.cs               
├── ViewModels/             # MVVM logic for state management and bindings
├── Views/                  # XAML pages for app screens and UI components
├── Services/               # Core business logic and sync services
│   ├── RealmService.cs 
├── Data/                   # Local and cloud database logic (Realm, MongoDB Atlas)    
│   ├── RealmConfig.cs               
├── Styles/                 # XAML resource dictionaries for consistent styling
├── Components/             # Reusable UI components like cards and progress bars
└── App.xaml                # Global app configuration and styles
```

## **Description**
- **Platforms/**: Contains platform-specific configurations, e.g., Android manifests or iOS entitlements.
- **Resources/**: Stores assets such as images, fonts, and theme colors.
- **Models/**: Represents the data layer, including Realm schemas for meals, exercises, and logs.
- **ViewModels/**: Contains logic for managing state and handling user interactions.
- **Views/**: The XAML-based UI for each screen (e.g., dashboard, meal tracker).
- **Services/**: Implements sync functionality and app-specific business logic.
- **Data/**: Handles database-related functionality, like Realm initialization and sync.
- **Styles/**: Defines reusable styles and themes for consistent UI design.
- **Components/**: Modular, reusable UI elements like cards, progress indicators, or charts.
- **App.xaml**: The entry point for global styles and app lifecycle management.
