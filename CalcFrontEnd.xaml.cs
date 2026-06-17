using System;
using System.Windows;
using System.Windows.Input;

namespace Calculator
{
    public partial class Form1 : Window
    {

        public Form1()
        {
            InitializeComponent();
            DataContext = new CalculatorViewModel();
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            var vm = (CalculatorViewModel)DataContext;
            switch (e.Key)
            {
                case Key.D0: case Key.NumPad0: vm.AppendDigitCommand.Execute("0"); break;
                case Key.D1: case Key.NumPad1: vm.AppendDigitCommand.Execute("1"); break;
                case Key.D2: case Key.NumPad2: vm.AppendDigitCommand.Execute("2"); break;
                case Key.D3: case Key.NumPad3: vm.AppendDigitCommand.Execute("3"); break;
                case Key.D4: case Key.NumPad4: vm.AppendDigitCommand.Execute("4"); break;

                // Makes sure that 5 is recognized as 5, and Shift+5 is recognized as percentage
                case Key.D5: case Key.NumPad5:
                    if (Keyboard.Modifiers == ModifierKeys.Shift) vm.PercentageCommand.Execute(null);
                    else { vm.AppendDigitCommand.Execute("5"); break; }
                    break;

                case Key.D6: case Key.NumPad6: vm.AppendDigitCommand.Execute("6"); break;
                case Key.D7: case Key.NumPad7: vm.AppendDigitCommand.Execute("7"); break;

                // Makes sure that 5 is recognized as 8, and Shift+8 is recognized as multiplication
                case Key.D8: case Key.NumPad8:
                    if (Keyboard.Modifiers == ModifierKeys.Shift) vm.MultiplyCommand.Execute(null);
                    else { vm.AppendDigitCommand.Execute("8"); break; }
                    break;

                case Key.D9: case Key.NumPad9: vm.AppendDigitCommand.Execute("9"); break;
                case Key.OemPeriod: case Key.Decimal: vm.DecimalCommand.Execute(null); break;
                case Key.Add: vm.AdditionCommand.Execute(null); break;
                case Key.Subtract: case Key.OemMinus: vm.SubtractCommand.Execute(null); break;
                case Key.Multiply: vm.MultiplyCommand.Execute(null); break;
                case Key.Divide: case Key.OemQuestion: vm.DivideCommand.Execute(null); break;

                // If Shift is held and presses plus button it uses addition.
                // If Shift is not held it shows the result of the equation input.
                case Key.OemPlus:
                    if (Keyboard.Modifiers == ModifierKeys.Shift) vm.AdditionCommand.Execute(null);
                    else vm.ResultCommand.Execute(null);
                    break;

                case Key.Return: vm.ResultCommand.Execute(null); break;
                case Key.Back: vm.DeleteCommand.Execute(null); break;
                case Key.Escape: vm.ClearCommand.Execute(null); break;
                case Key.Delete: vm.ClearEntryCommand.Execute(null); break;
            }
            e.Handled = true;
        }

    }
}
