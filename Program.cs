// Program.cs is the very first thing that runs when you launch the app.
// Its job is to configure Avalonia and hand off control to the framework,
// which then calls App.Initialize() and App.OnFrameworkInitializationCompleted().

using Avalonia;

namespace Calculator
{
    class Program
    {
        // [STAThread] tells Windows this app runs on a single UI thread and is 
        // required for any desktop GUI app on Windows.
        [System.STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args); // starts the window + event loop

        // Configures Avalonia before the app launches.
        // UsePlatformDetect() automatically picks the right backend for the OS
        // (Win32 on Windows, Cocoa on Mac, X11/Wayland on Linux).
        // LogToTrace() sends Avalonia's internal logs to the debug output window.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
    }
}
