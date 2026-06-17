using System;                  
using System.ComponentModel;
using System.Windows.Input;

namespace Calculator
{

  public class CalculatorViewModel : INotifyPropertyChanged
  {

    public ICommand ClearCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand AdditionCommand { get; }
    public ICommand SquareRootCommand { get; }
    public ICommand ExponentCommand { get; }
    public ICommand ClearEntryCommand { get; }
    public ICommand DivideCommand { get; }
    public ICommand NegativePositiveCommand { get; }
    public ICommand PercentageCommand { get; }
    public ICommand ReciprocalCommand { get; }
    public ICommand MultiplyCommand { get; }
    public ICommand SubtractCommand { get; }
    public ICommand DecimalCommand { get; }
    public ICommand AppendDigitCommand { get; }
    public ICommand ResultCommand { get; }



    public CalculatorViewModel()
        {
            ResultCommand = new RelayCommand(_ => HandleResult());
            AppendDigitCommand = new RelayCommand(param => HandleAppendDigit(param?.ToString() ?? string.Empty));
            DecimalCommand = new RelayCommand(_ => HandleAppendDigit("."));
            ClearCommand = new RelayCommand(_ => HandleClear());
            DeleteCommand = new RelayCommand(_ => HandleDelete());
            SquareRootCommand = new RelayCommand(_ => HandleSquareRoot());
            AdditionCommand = new RelayCommand(_ => HandleAddition());
            SubtractCommand = new RelayCommand(_ => HandleSubtract());
            ClearEntryCommand = new RelayCommand(_ => HandleClearEntry());
            DivideCommand = new RelayCommand(_ => HandleDivide());
            NegativePositiveCommand = new RelayCommand(_ => HandleNegativePositive());
            PercentageCommand = new RelayCommand(_ => HandlePercentage());
            ReciprocalCommand = new RelayCommand(_ => HandleReciprocal());
            ExponentCommand = new RelayCommand(_ => HandleExponent());
            MultiplyCommand = new RelayCommand(_ => HandleMultiply());
        }

    // Is in charge of outputting numbers onto viewing screen
    private void HandleAppendDigit(string digit)
    {
        _input += digit;
        DisplayText = _input;
    }

    private void HandleAddition()
        {
            _operand1 = _input;
            _operation = '+';
            _input = string.Empty;
            ExpressionText = $"{_operand1} + ";
        }


    private void HandleSubtract()
        {
            _operand1 = _input;
            _operation = '-';
            _input = string.Empty;
            ExpressionText = $"{_operand1} - ";
        }

      private void HandleDivide()
        {
            _operand1 = _input;
            _operation = '/';
            _input = string.Empty;
            ExpressionText = $"{_operand1} ÷ ";
        }

    private void HandleMultiply()
        {
            _operand1 = _input;
            _operation = '*';
            _input = string.Empty;
            ExpressionText = $"{_operand1} × ";
        }

    private void HandleExponent()
        {
            double.TryParse(_input, out double num);
            _input = Math.Pow(num, 2).ToString();
            ExpressionText = $"{_operand1}² ";
            DisplayText = _input;

        }

    private void HandlePercentage()
        {
            double.TryParse(_input, out double num);
            _input = (num / 100).ToString();
            DisplayText = _input;
        }


    //Clears all progress in calculator
    private void HandleClear()
        {
            DisplayText= "";
            _input = string.Empty;
            _operand1 = string.Empty;
            _operand2 = string.Empty;
            _operation = '\0';
            _result = 0.0;
            ExpressionText = string.Empty;
        }

    // Clears only most recently typed number
    private void HandleClearEntry()
        {
            DisplayText = "";
            _input = string.Empty;
        }


    private void HandleDelete()
        {
            if (_input.Length > 0)
            {
                _input = _input.Remove(_input.Length - 1);
                DisplayText = _input;
            }
        }


    private void HandleNegativePositive()
        {
            double.TryParse(_input, out double num);
            _input = (num * -1).ToString();
            DisplayText = _input;
        }


    private void HandleReciprocal()
        {
            double.TryParse(_input, out double num);
            _input = (1 / num).ToString();
            ExpressionText = $"1/{_operand1} ";
            DisplayText = _input;
        }


    private void HandleSquareRoot()
        {
            double.TryParse(_input, out double num);
            _input = (Math.Sqrt(num)).ToString();
            ExpressionText = $"√{_operand1} ";
            DisplayText = _input;
        }

    private void HandleResult()
        {
            _operand2 = _input;
            double.TryParse(_operand1, out double num1);
            double.TryParse(_operand2, out double num2);

            if (_operation == '+')
                _result = num1 + num2;

            else if (_operation == '-')
                _result = num1 - num2;

            else if (_operation == '*')
                _result = num1 * num2;

            else if (_operation == '/')
            {
                if (num2 != 0)
                    _result = num1 / num2;
                else
                {
                    DisplayText = "Cannot divide by zero"; 
                    return;
                }
            }

            DisplayText = _result.ToString();
            _input = _result.ToString();
            ExpressionText = $"{_operand1} {_operation} {_operand2} =";
            // After showing the result, the expression row freezes at the full equation
            // (e.g. "25 - 5 =") until the user starts a new entry.
        }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        private string _input = string.Empty;
        private string _operand1 = string.Empty;
        private string _operand2 = string.Empty;
        private char _operation;
        private double _result = 0.0;  

        private string _displayText = "";
        public string DisplayText
        {
            get => _displayText;
            set
            {
                _displayText = value;
                OnPropertyChanged();
            }
        }

        private string _expressionText = "";
        public string ExpressionText
        {
            get => _expressionText;
            set
            {
                _expressionText = value;
                OnPropertyChanged();
            }
        }

    }
}