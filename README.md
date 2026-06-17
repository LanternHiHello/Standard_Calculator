**A cross-platform calculator built with C#, .NET 8, and Avalonia UI**

**Features list:**

  *  Basic arithmetic (add, subtract, multiply, divide)
  *  Percentage, square root, reciprocal, square (x²)
  *  Toggle positive/negative (+/-)
  *  Clear all (C), clear entry (CE), backspace (⌫)
  *  Expression display — shows the running equation in gray above the result, matching Microsoft Calculator style
  *  Full keyboard support (digits, operators, Enter/= for result, Escape for clear, Delete for CE, Backspace to delete)
  *  Responsive layout — buttons and display scale with window size
  *  Runs on Windows, macOS, and Linux via Avalonia UI

**Requirements:**

*  .NET 8 SDK
*  Windows, macOS, or Linux



**How to build and run:**

  `dotnet build`

  `dotnet run --project Stuller.Calc.csproj`



**What each file contains and is used for:**

  *  CalcFrontEnd.xaml — UI layout and styling (Avalonia XAML)
  *  CalcFrontEnd.xaml.cs — keyboard input handler
  *  CalculatorViewModel.cs — all calculator logic and state (MVVM pattern)
  *  RelayCommand.cs — ICommand implementation used to bind buttons to ViewModel methods
  *  App.xaml — declares the Avalonia application and loads the FluentTheme
  *  App.xaml.cs — creates and shows the main window when the app starts
  *  Program.cs — application startup and Avalonia AppBuilder configuration
  *  Stuller.Calc.csproj — project file defining the SDK, target framework, and NuGet packages
  *  Assets/ — application icon and other static resources
  *  AvaloniaExample.axaml — reference file showing the Avalonia version of the UI (not compiled into the app)
  *  .gitignore — tells git to ignore build output (bin/, obj/), IDE files (.vs/), and generated temp project files
