// This is the code-behind for App.xaml and handles the app's startup sequence.
// Think of it as the "launch" file, it doesn't contain any calculator logic,
// it just gets Avalonia set up and opens the main window.

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace Calculator
{
    public partial class App : Application
    {
        // Avalonia calls this first thing on startup.
        // AvaloniaXamlLoader.Load(this) reads App.xaml and applies everything in it,
        // in our case that's the FluentTheme, which gives all controls their default look.
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        // Called after Initialize() once the framework is fully ready.
        // This is where we create the main window and tell Avalonia to show it.
        // IClassicDesktopStyleApplicationLifetime is the desktop mode (Windows/Mac/Linux).
        // Avalonia also supports mobile and browser lifetimes, which is why we check the type.
        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var window = new MainWindow();
                // Setting MainWindow tells Avalonia to keep the app alive until this window closes
                desktop.MainWindow = window;
                window.Show();
            }
            base.OnFrameworkInitializationCompleted();
        }
    }
}
