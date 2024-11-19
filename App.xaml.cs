namespace PleaseApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // TODO: Add initialization logic, e.g., logging or analytics setup.
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // TODO: Customize window properties if necessary (e.g., title, dimensions).
        return new Window(new AppShell())
        {
            Title = "Please App", // Set a default window title
        };
    }
}
