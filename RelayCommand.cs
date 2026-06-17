// RelayCommand is a small helper that lets us use plain methods as ICommand objects.
//
// The XAML binding system only knows how to talk to ICommand, it can't call a method directly.
// RelayCommand bridges that gap: you hand it a method (like HandleClear), and it wraps it
// up as an ICommand that a button's Command= binding can use.
//
// Usage in ViewModel:
//   ClearCommand = new RelayCommand(_ => HandleClear());
//
// Usage in XAML:
//   <Button Command="{Binding ClearCommand}" />

using System;
using System.Windows.Input;

namespace Calculator
{
    public class RelayCommand : ICommand
    {
        // Stores the method to run when the command executes
        private readonly Action<object?> _execute;

        // Constructor — just pass in the method you want the command to call
        public RelayCommand(Action<object?> execute) => _execute = execute;

        // Always returns true — all buttons in this calculator are always enabled.
        // If you ever wanted to disable a button you'd change this to return false 
        // in those situations.
        public bool CanExecute(object? parameter) => true;

        // Called by the binding system when the button is clicked.
        // Passes along the CommandParameter from the XAML (ex. "7" for the 7 button),
        // or null if no parameter was set.
        public void Execute(object? parameter) => _execute(parameter);

        // Required by ICommand, it's fired when CanExecute might have changed.
        // We wire it to Avalonia's built-in requery system so the framework
        // can ask "should this button still be enabled?" at the right times.
        public event EventHandler? CanExecuteChanged;
    }
}
