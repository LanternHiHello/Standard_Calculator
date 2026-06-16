using System;
using System.Windows;

namespace Calculator
{
    public partial class Form1 : Window
    {
        private string input = string.Empty;
        private string operand1 = string.Empty;
        private string operand2 = string.Empty;
        private char operation;
        private double result = 0.0;

        public Form1()
        {
            InitializeComponent();
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            input += "0";
            viewWindow.Text = input;
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            input += "1";
            viewWindow.Text = input;
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            input += "2";
            viewWindow.Text = input;
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            input += "3";
            viewWindow.Text = input;
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            input += "4";
            viewWindow.Text = input;
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            input += "5";
            viewWindow.Text = input;
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            input += "6";
            viewWindow.Text = input;
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            input += "7";
            viewWindow.Text = input;
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            input += "8";
            viewWindow.Text = input;
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            input += "9";
            viewWindow.Text = input;
        }

        private void dot_Click(object sender, RoutedEventArgs e)
        {
            input += ".";
            viewWindow.Text = input;
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            operand1 = input;
            operation = '+';
            input = string.Empty;
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            operand1 = input;
            operation = '-';
            input = string.Empty;
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            operand1 = input;
            operation = '/';
            input = string.Empty;
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            operand1 = input;
            operation = '*';
            input = string.Empty;
        }

        private void exponent_Click(object sender, RoutedEventArgs e)
        {
            operand1 = input;
            operation = '^';
        }

        private void percentage_Click(object sender, RoutedEventArgs e)
        {
            operand1 = input;
            operation = '%';
            input = string.Empty;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            viewWindow.Text = "";
            input = string.Empty;
            operand1 = string.Empty;
            operand2 = string.Empty;
        }

        private void clear_Entry_Click(object sender, RoutedEventArgs e)
        {
            viewWindow.Text = "";
            input = string.Empty;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (input.Length > 0)
            {
                input = input.Substring(0, input.Length - 1);
                viewWindow.Text = input;
            }
        }

        private void negative_Positive_Click(object sender, RoutedEventArgs e)
        {
            operand1 = input;
            operation = '@';
            input = string.Empty;
        }

        private void reciprocal_Click(object sender, RoutedEventArgs e)
        {
            operand1 = input;
            operation = '`';
            input = string.Empty;
        }

        private void square_Root_Click(object sender, RoutedEventArgs e)
        {
            operand1 = input;
            operation = '$';
            input = string.Empty;
        }

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
                    viewWindow.Text = "Cannot divide by zero";
                    return;
                }
            }
            else if (operation == '^')
                result = Math.Pow(num1, 2);
            else if (operation == '%')
                result = num1 / 100;
            else if (operation == '`')
                result = 1 / num1;
            else if (operation == '$')
                result = Math.Sqrt(num1);
            else if (operation == '@')
                result = num1 * -1;

            viewWindow.Text = result.ToString();
            input = result.ToString();
        }
    }
}
