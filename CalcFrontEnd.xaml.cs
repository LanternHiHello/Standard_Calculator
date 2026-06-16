using System;
using System.Windows;
using System.Windows.Input;

namespace Calculator
{
    // TODO (MVVM - View): This class should become a thin "View" with almost no logic.
    // Steps:
    //   1. Create a new file called CalculatorViewModel.cs in this project.
    //   2. Move all state fields (input, operand1, operand2, operation, result) into the ViewModel.
    //   3. Move all the calculator logic methods into the ViewModel as well.
    //   4. In this constructor below, set: DataContext = new CalculatorViewModel();
    //   5. The only code that should remain here is InitializeComponent() and the OnKeyDown override,
    //      since keyboard handling requires access to the WPF Keyboard class (a View concern).
    //      In OnKeyDown, instead of calling click handlers directly, call ViewModel commands:
    //      e.g. ((CalculatorViewModel)DataContext).PlusCommand.Execute(null);
    public partial class Form1 : Window
    {
        // TODO (MVVM - State): Move these five fields into CalculatorViewModel.cs as private fields.
        // The ViewModel will own the calculator state, not the View.
        private string input = string.Empty;
        private string operand1 = string.Empty;
        private string operand2 = string.Empty;
        private char operation;
        private double result = 0.0;

        public Form1()
        {
            InitializeComponent();
            // TODO (MVVM - DataContext): After creating CalculatorViewModel, add this line:
            // DataContext = new CalculatorViewModel();
        }

        // TODO (MVVM - Commands): Each of the click handlers below should become an ICommand property
        // on the CalculatorViewModel. Use a RelayCommand class to wrap the logic in a command.
        //
        // Example — create a RelayCommand.cs file with this class:
        //
        //   public class RelayCommand : ICommand
        //   {
        //       private readonly Action<object> _execute;
        //       public RelayCommand(Action<object> execute) => _execute = execute;
        //       public bool CanExecute(object parameter) => true;
        //       public void Execute(object parameter) => _execute(parameter);
        //       public event EventHandler CanExecuteChanged;
        //   }
        //
        // Then in CalculatorViewModel, expose each command as a property, e.g.:
        //   public ICommand PlusCommand => new RelayCommand(_ => HandlePlus());
        //
        // In XAML, replace Click="plus_Click" with Command="{Binding PlusCommand}".

        // TODO (MVVM - DisplayText): Every method below that sets viewWindow.Text should instead
        // set a ViewModel property called DisplayText. That property raises PropertyChanged so the
        // XAML TextBlock updates automatically via binding (Text="{Binding DisplayText}").
        // The ViewModel must implement INotifyPropertyChanged for this to work.
        //
        // Example ViewModel property:
        //   private string _displayText = "";
        //   public string DisplayText
        //   {
        //       get => _displayText;
        //       set { _displayText = value; OnPropertyChanged(); }
        //   }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            input += "0";
            viewWindow.Text = input; // TODO (MVVM): Remove. Set DisplayText = input in ViewModel instead.
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            input += "1";
            viewWindow.Text = input; // TODO (MVVM): Remove. Set DisplayText = input in ViewModel instead.
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            input += "2";
            viewWindow.Text = input; // TODO (MVVM): Remove. Set DisplayText = input in ViewModel instead.
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            input += "3";
            viewWindow.Text = input; // TODO (MVVM): Remove. Set DisplayText = input in ViewModel instead.
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            input += "4";
            viewWindow.Text = input; // TODO (MVVM): Remove. Set DisplayText = input in ViewModel instead.
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            input += "5";
            viewWindow.Text = input; // TODO (MVVM): Remove. Set DisplayText = input in ViewModel instead.
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            input += "6";
            viewWindow.Text = input; // TODO (MVVM): Remove. Set DisplayText = input in ViewModel instead.
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            input += "7";
            viewWindow.Text = input; // TODO (MVVM): Remove. Set DisplayText = input in ViewModel instead.
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            input += "8";
            viewWindow.Text = input; // TODO (MVVM): Remove. Set DisplayText = input in ViewModel instead.
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            input += "9";
            viewWindow.Text = input; // TODO (MVVM): Remove. Set DisplayText = input in ViewModel instead.
        }

        private void dot_Click(object sender, RoutedEventArgs e)
        {
            input += ".";
            viewWindow.Text = input; // TODO (MVVM): Remove. Set DisplayText = input in ViewModel instead.
        }

        // TODO (MVVM): Move this method's logic into CalculatorViewModel as a private HandlePlus() method,
        // then expose it via: public ICommand PlusCommand => new RelayCommand(_ => HandlePlus());
        private void plus_Click(object sender, RoutedEventArgs e)
        {
            operand1 = input;
            operation = '+';
            input = string.Empty;
        }

        // TODO (MVVM): Move to ViewModel. Expose as MinusCommand.
        private void minus_Click(object sender, RoutedEventArgs e)
        {
            operand1 = input;
            operation = '-';
            input = string.Empty;
        }

        // TODO (MVVM): Move to ViewModel. Expose as DivideCommand.
        private void divide_Click(object sender, RoutedEventArgs e)
        {
            operand1 = input;
            operation = '/';
            input = string.Empty;
        }

        // TODO (MVVM): Move to ViewModel. Expose as MultiplyCommand.
        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            operand1 = input;
            operation = '*';
            input = string.Empty;
        }

        // TODO (MVVM): Move to ViewModel. Expose as ExponentCommand.
        private void exponent_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(input, out double num);
            input = Math.Pow(num, 2).ToString();
            viewWindow.Text = input;

        }

        // TODO (MVVM): Move to ViewModel. Expose as PercentageCommand.
        private void percentage_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(input, out double num);
            input = (num / 100).ToString();
            viewWindow.Text = input;
        }


        //Clears all progress in calculator
        // TODO (MVVM): Move to ViewModel. Expose as ClearCommand.
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            viewWindow.Text = "";
            input = string.Empty;
            operand1 = string.Empty;
            operand2 = string.Empty;
        }

        // Clears only most recently typed number
        // TODO (MVVM): Move to ViewModel. Expose as ClearEntryCommand.
        private void clear_Entry_Click(object sender, RoutedEventArgs e)
        {
            viewWindow.Text = "";
            input = string.Empty;
        }

        // TODO (MVVM): Move to ViewModel. Expose as DeleteCommand.
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (input.Length > 0)
            {
                input = input.Remove(input.Length - 1);
                viewWindow.Text = input;
            }
        }

        // TODO (MVVM): Move to ViewModel. Expose as NegativePositiveCommand.
        private void negative_Positive_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(input, out double num);
            input = (num * -1).ToString();
            viewWindow.Text = input;
        }

        // TODO (MVVM): Move to ViewModel. Expose as ReciprocalCommand.
        private void reciprocal_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(input, out double num);
            input = (1 / num).ToString();
            viewWindow.Text = input;
        }

        // TODO (MVVM): Move to ViewModel. Expose as SquareRootCommand.
        private void square_Root_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(input, out double num);
            input = (Math.Sqrt(num)).ToString();
            viewWindow.Text = input;
        }

        // Assigning key presses to typing into calculator, allows inputs from numpad and also regular number keys
        // TODO (MVVM): Keep this method in the View (keyboard input is a View concern), but replace all
        // direct method calls with ViewModel command calls, e.g.:
        //   var vm = (CalculatorViewModel)DataContext;
        //   vm.PlusCommand.Execute(null);
        // Also replace direct "input +=" lines with a ViewModel command, e.g. vm.AppendDigitCommand.Execute("0");
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.Key)
            {
                case Key.D0: case Key.NumPad0: input += "0"; viewWindow.Text = input; break;
                case Key.D1: case Key.NumPad1: input += "1"; viewWindow.Text = input; break;
                case Key.D2: case Key.NumPad2: input += "2"; viewWindow.Text = input; break;
                case Key.D3: case Key.NumPad3: input += "3"; viewWindow.Text = input; break;
                case Key.D4: case Key.NumPad4: input += "4"; viewWindow.Text = input; break;

                // Makes sure that 5 is recognized as 5, and Shift+5 is recognized as percentage
                case Key.D5: case Key.NumPad5:
                    if (Keyboard.Modifiers == ModifierKeys.Shift) percentage_Click(this, new RoutedEventArgs());
                    else { input += "5"; viewWindow.Text = input; }
                    break;

                case Key.D6: case Key.NumPad6: input += "6"; viewWindow.Text = input; break;
                case Key.D7: case Key.NumPad7: input += "7"; viewWindow.Text = input; break;

                // Makes sure that 5 is recognized as 8, and Shift+8 is recognized as multiplication
                case Key.D8: case Key.NumPad8:
                    if (Keyboard.Modifiers == ModifierKeys.Shift) multiply_Click(this, new RoutedEventArgs());
                    else { input += "8"; viewWindow.Text = input; }
                    break;

                case Key.D9: case Key.NumPad9: input += "9"; viewWindow.Text = input; break;
                case Key.OemPeriod: case Key.Decimal: dot_Click(this, new RoutedEventArgs()); break;
                case Key.Add: plus_Click(this, new RoutedEventArgs()); break;
                case Key.Subtract: case Key.OemMinus: minus_Click(this, new RoutedEventArgs()); break;
                case Key.Multiply: multiply_Click(this, new RoutedEventArgs()); break;
                case Key.Divide: case Key.OemQuestion: divide_Click(this, new RoutedEventArgs()); break;

                // If Shift is held and presses plus button it uses addition.
                // If Shift is not held it shows the result of the equation input.
                case Key.OemPlus:
                    if (Keyboard.Modifiers == ModifierKeys.Shift) plus_Click(this, new RoutedEventArgs());
                    else equals_Click(this, new RoutedEventArgs());
                    break;

                case Key.Return: equals_Click(this, new RoutedEventArgs()); break;
                case Key.Back: delete_Click(this, new RoutedEventArgs()); break;
                case Key.Escape: clear_Click(this, new RoutedEventArgs()); break;
                case Key.Delete: clear_Entry_Click(this, new RoutedEventArgs()); break;
            }
            e.Handled = true;
        }

        // TODO (MVVM): Move to ViewModel. Expose as EqualsCommand.
        private void equals_Click(object sender, RoutedEventArgs e)
        {
            operand2 = input;
            double.TryParse(operand1, out double num1);
            double.TryParse(operand2, out double num2);

            if (operation == '+')
                result = num1 + num2;

            else if (operation == '-')
                result = num1 - num2;

            else if (operation == '*')
                result = num1 * num2;

            else if (operation == '/')
            {
                if (num2 != 0)
                    result = num1 / num2;
                else
                {
                    viewWindow.Text = "Cannot divide by zero"; // TODO (MVVM): Set DisplayText = "Cannot divide by zero" in ViewModel instead.
                    return;
                }
            }

            viewWindow.Text = result.ToString(); // TODO (MVVM): Remove. Set DisplayText = result.ToString() in ViewModel instead.
            input = result.ToString();
        }
    }
}
