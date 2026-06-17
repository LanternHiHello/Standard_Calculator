// This is the code-behind for CalcFrontEnd.xaml.
// Its only job is handling keyboard input, all actual calculator logic
// lives in CalculatorViewModel.cs, not here.

using Avalonia.Controls;
using Avalonia.Input;

namespace Calculator
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            // Builds the UI from the XAML file, generated automatically by Avalonia at build time
            InitializeComponent();
            // Connects the ViewModel to the window so all the Binding expressions in the
            // XAML can find their data (DisplayText, commands, etc.)
            DataContext = new CalculatorViewModel();
        }


        // Avalonia calls this whenever a key is pressed while the window has focus.
        // We intercept it here and fire the right command on the ViewModel, so 
        // keyboard input works exactly the same as clicking the on-screen buttons.
        //
        // Using OnKeyDown means the window sees the key first, before any focused
        // button can accidentally intercept it.
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Grab the ViewModel from DataContext so we can call its commands
            var vm = (CalculatorViewModel)DataContext!;
            switch (e.Key)
            {
                // Digits, each key fires AppendDigitCommand with the number as a string
                // D0-D9 are the number row keys; NumPad0-9 are the numpad keys
                case Key.D0: case Key.NumPad0: vm.AppendDigitCommand.Execute("0"); break;
                case Key.D1: case Key.NumPad1: vm.AppendDigitCommand.Execute("1"); break;
                case Key.D2: case Key.NumPad2: vm.AppendDigitCommand.Execute("2"); break;
                case Key.D3: case Key.NumPad3: vm.AppendDigitCommand.Execute("3"); break;
                case Key.D4: case Key.NumPad4: vm.AppendDigitCommand.Execute("4"); break;

                // 5 and Shift+5 share the same key — Shift+5 is % on a US keyboard, so
                // this is making sure the % is treated as a separate entity than 5
                case Key.D5: case Key.NumPad5:
                    if (e.KeyModifiers == KeyModifiers.Shift) vm.PercentageCommand.Execute(null);
                    else { vm.AppendDigitCommand.Execute("5"); break; }
                    break;

                case Key.D6: case Key.NumPad6: vm.AppendDigitCommand.Execute("6"); break;
                case Key.D7: case Key.NumPad7: vm.AppendDigitCommand.Execute("7"); break;

                // 8 and Shift+8 share the same key — Shift+8 is * on a US keyboard, so
                // this is making sure the * is treated as a separate entity than 8
                case Key.D8: case Key.NumPad8:
                    if (e.KeyModifiers == KeyModifiers.Shift) vm.MultiplyCommand.Execute(null);
                    else { vm.AppendDigitCommand.Execute("8"); break; }
                    break;

                case Key.D9: case Key.NumPad9: vm.AppendDigitCommand.Execute("9"); break;

                // Decimal point — OemPeriod is the . on the main keyboard, Decimal is the numpad .
                case Key.OemPeriod: case Key.Decimal: vm.DecimalCommand.Execute(null); break;

                // Operators — each maps to its command
                // Add/Subtract/Multiply/Divide are numpad keys; Oem keys are the main keyboard equivalents
                case Key.Add:      vm.AdditionCommand.Execute(null); break;
                case Key.Subtract: case Key.OemMinus:    vm.SubtractCommand.Execute(null); break;
                case Key.Multiply: vm.MultiplyCommand.Execute(null); break;
                case Key.Divide:   case Key.OemQuestion: vm.DivideCommand.Execute(null); break;

                // OemPlus is the = key on the main keyboard (same physical key as +)
                // Shift+OemPlus is +, without Shift it's =, so
                // this is making sure the = is treated as a separate entity than +
                case Key.OemPlus:
                    if (e.KeyModifiers == KeyModifiers.Shift) vm.AdditionCommand.Execute(null);
                    else vm.ResultCommand.Execute(null);
                    break;

                // Enter and = both show the result
                case Key.Return: vm.ResultCommand.Execute(null); break;
                // Backspace deletes the last digit typed
                case Key.Back:   vm.DeleteCommand.Execute(null); break;
                // Escape clears everything
                case Key.Escape: vm.ClearCommand.Execute(null); break;
                // Delete clears only the current entry (CE)
                case Key.Delete: vm.ClearEntryCommand.Execute(null); break;
            }

            // Mark the event as handled so it doesn't bubble further up the UI tree
            e.Handled = true;
            base.OnKeyDown(e);
        }

    }
}
