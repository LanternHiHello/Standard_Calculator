using System;
using System.ComponentModel;
using System.Windows.Input;

// The flow when a button is pressed:
//   Button clicked → Command fires → Handle method runs → state fields update
//   → DisplayText / ExpressionText change → Avalonia notices and refreshes the screen

namespace Calculator
{

  public class CalculatorViewModel : INotifyPropertyChanged
  {

    // Each of these is wired up to a button in the XAML
    // When that button is clicked, the matching command runs its Handle method 
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


    // Here we hook each command up to its handler method using RelayCommand.
    // RelayCommand is just a small wrapper that lets us pass a regular method
    // to the binding system so it can be called from a button click.
    // The '_' means we're ignoring the command parameter for most of these.
    // AppendDigitCommand is the exception, it reads the button's CommandParameter
    // (ex. "7") to know which number to add.
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


    // Adds a number (or a decimal point) to what the user is typing and updates the display.
    private void HandleAppendDigit(string digit)
    {
        _input += digit;
        DisplayText = _input;
    }


    // The four operator handlers (+, -, *, /) all do the same three things:
    //   1. Save whatever the user typed as the first number (_operand1)
    //   2. Remember which operator was picked (_operation)
    //   3. Clear _input so the user can start typing the second number
    // The expression label (e.g. "25 + ") is also updated here so the user
    // can see what they've entered so far.

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


    // These operations work on just one number — no second number needed.
    // They grab whatever is currently in _input, do their thing, and show the result.

    // Raises the current number to the power of 2 (ex. 5 → 25)
    private void HandleExponent()
        {
            double.TryParse(_input, out double num);
            _input = Math.Pow(num, 2).ToString();
            ExpressionText = $"{_operand1}² ";
            DisplayText = _input;
        }

    // Divides the current number by 100 (ex. 75 → 0.75)
    private void HandlePercentage()
        {
            double.TryParse(_input, out double num);
            _input = (num / 100).ToString();
            DisplayText = _input;
        }

    // Flips the sign — positive becomes negative and vice versa
    private void HandleNegativePositive()
        {
            double.TryParse(_input, out double num);
            _input = (num * -1).ToString();
            DisplayText = _input;
        }

    // Computes 1 divided by the current number (ex. 4 → 0.25)
    private void HandleReciprocal()
        {
            double.TryParse(_input, out double num);
            _input = (1 / num).ToString();
            ExpressionText = $"1/{_operand1} ";
            DisplayText = _input;
        }

    // Takes the square root of the current number (ex. 9 → 3)
    private void HandleSquareRoot()
        {
            double.TryParse(_input, out double num);
            _input = (Math.Sqrt(num)).ToString();
            ExpressionText = $"√{_operand1} ";
            DisplayText = _input;
        }


    // Wipes everything clean, number typed, operator, first number, all of it.
    // _operation is reset to null so a leftover operator from
    // a previous calculation can't accidentally carry over into the next one.
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

    // CE (Clear Entry) — only clears the number currently being typed.
    // Unlike full Clear, it leaves the first number and operator alone,
    // so the user can just retype the second number without starting over.
    private void HandleClearEntry()
        {
            DisplayText = "";
            _input = string.Empty;
        }

    // Removes the last character the user typed, like a backspace.
    // Does nothing if there's nothing left to delete.
    private void HandleDelete()
        {
            if (_input.Length > 0)
            {
                _input = _input.Remove(_input.Length - 1);
                DisplayText = _input;
            }
        }


    // Fired when the user presses = or Enter.
    // Grabs the two numbers and the operator, does the math, and shows the answer.
    // The result is also stored back into _input so if the user immediately
    // presses another operator, the answer becomes the new first number.
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
                    // Can't divide by zero — bail out early with an error message
                    DisplayText = "Cannot divide by zero";
                    return;
                }
            }

            DisplayText = _result.ToString();
            _input = _result.ToString();
            // Lock the expression label to show the full completed equation (ex. "25 - 5 =")
            ExpressionText = $"{_operand1} {_operation} {_operand2} =";
        }


    // This event is how we tell Avalonia "hey, a property changed, please update the screen".
    // It's required by the INotifyPropertyChanged interface that this class implements.
    public event PropertyChangedEventHandler? PropertyChanged;

    // Fires PropertyChanged for whichever property calls this.
    // [CallerMemberName] is a compiler trick that automatically fills in the property name,
    // so when DisplayText's setter calls OnPropertyChanged(), it already knows the name is
    // "DisplayText" without us having to type it as a string.
    private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


    // These six fields are the full state of the calculator at any given moment.
    // _input     — what the user is currently typing
    // _operand1  — the first number, saved when an operator is pressed
    // _operand2  — the second number, saved when = is pressed
    // _operation — the chosen operator (+, -, *, /), or null if none yet
    // _result    — the answer from the last calculation
    private string _input = string.Empty;
    private string _operand1 = string.Empty;
    private string _operand2 = string.Empty;
    private char _operation;
    private double _result = 0.0;

    // These two properties are what the XAML TextBlocks bind to.
    // Setting them automatically calls OnPropertyChanged, which triggers the screen refresh.

    // The big number shown in the main display area
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

    // The small gray equation shown above the result
    // (shows "25 - " while the user types, then "25 - 5 =" after pressing =)
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
