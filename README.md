A WPF calculator built with C# and .NET 8

Features list:

  *  Basic arithmetic (add, subtract, multiply, divide)
  *  Percentage, square root, reciprocal, square (x²)
  *  Toggle positive/negative (+/-)
  *  Clear all (C), clear entry (CE), backspace (⌫)
  *  Responsive layout — buttons and display scale with window size
  
Requirements:

*  .NET 8 SDK or Runtime
*  Windows (WPF is Windows-only)


How to build and run:

  dotnet build
  
  dotnet run --project Stuller.Calc.csproj


What each file contains and is used for:

  *  CalcFrontEnd.xaml — UI layout and styling
  *  CalcFrontEnd.xaml.cs — calculator logic and event handlers
  *  App.xaml / App.xaml.cs — application entry point
