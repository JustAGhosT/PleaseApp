using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;
using PleaseApp;
using PleaseApp.ViewModels;
using PleaseApp.Views;

namespace PleaseApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            // Add more detailed logging in debug mode
            builder.Logging.AddDebug();
#endif

            // Configure dependency injection
            ConfigureServices(builder.Services);

            // Platform-specific configuration (optional, can add iOS/Android/Windows-specific logic)
            ConfigurePlatforms(builder);

            return builder.Build();
        }

        /// <summary>
        /// Configures services and dependencies for dependency injection.
        /// </summary>
        /// <param name="services">Service collection to register dependencies.</param>
        private static void ConfigureServices(IServiceCollection services)
        {
            // Register RealmService
            services.AddSingleton<RealmService>(); // Singleton ensures only one instance is used throughout the app.

            // Register ViewModels
            services.AddTransient<MainViewModel>(); // Transient for new instances each time.
            services.AddTransient<MealViewModel>();

            // Register Views
            services.AddTransient<MainPage>();
            services.AddTransient<MealView>();

            // TODO: Add other shared services as needed (e.g., API clients, analytics tools).
        }

        /// <summary>
        /// Configures platform-specific settings if needed.
        /// </summary>
        /// <param name="builder">The MauiApp builder instance.</param>
        private static void ConfigurePlatforms(MauiAppBuilder builder)
        {
            // Example: Add platform-specific logic here if needed.
#if ANDROID
            // Add Android-specific settings
#endif
#if IOS
            // Add iOS-specific settings
#endif
#if WINDOWS
            // Add Windows-specific settings
#endif
        }
    }
}
