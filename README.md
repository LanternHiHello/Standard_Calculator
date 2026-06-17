**A WPF calculator built with C# and .NET 8**

**Features list:**

  *  Basic arithmetic (add, subtract, multiply, divide)
  *  Percentage, square root, reciprocal, square (x²)
  *  Toggle positive/negative (+/-)
  *  Clear all (C), clear entry (CE), backspace (⌫)
  *  Expression display — shows the running equation in gray above the result, matching Microsoft Calculator style
  *  Full keyboard support (digits, operators, Enter/= for result, Escape for clear, Delete for CE, Backspace to delete)
  *  Responsive layout — buttons and display scale with window size

**Requirements:**

*  .NET 8 SDK or Runtime
*  Windows (WPF is Windows-only)



**How to build and run:**

  `dotnet build`
  
  `dotnet run --project Stuller.Calc.csproj`



**What each file contains and is used for:**

  *  CalcFrontEnd.xaml — UI layout and styling
  *  CalcFrontEnd.xaml.cs — keyboard input handler
  *  CalculatorViewModel.cs — all calculator logic and state (MVVM pattern)
  *  RelayCommand.cs — ICommand implementation used to bind buttons to ViewModel methods
  *  App.xaml / App.xaml.cs — application entry point
