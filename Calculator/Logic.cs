using System;

public class Logic
{
    private readonly Calculator _calculator;
    private readonly IUserInterface _ui;

    public Logic(Calculator calculator, IUserInterface ui)
    {
        _calculator = calculator;
        _ui = ui;
    }

    public void Run()
    {
        while (true)
        {
            _ui.Write("\n=== Simple Calculator ===\n");
            _ui.Write("1. Sum\n2. Subtract\n3. Multiply\n4. Divide\n5. Exit\nChoose: ");
            string choice = _ui.Read();

            if (choice == "5") break;

            double a = ReadNumber("Enter first number: ");
            double b = ReadNumber("Enter second number: ");

            try
            {
                double result = choice switch
                {
                    "1" => _calculator.Sum(a, b),
                    "2" => _calculator.Subtract(a, b),
                    "3" => _calculator.Multiply(a, b),
                    "4" => _calculator.Divide(a, b),
                    _ => throw new InvalidOperationException("Invalid choice")
                };
                _ui.Write($"Result: {result}\n");
            }
            catch (Exception ex)
            {
                _ui.Write($"Error: {ex.Message}\n");
            }
        }
    }

    private double ReadNumber(string message)
    {
        _ui.Write(message);
        double num;

        while (!double.TryParse(_ui.Read(), out num))
        {
            _ui.Write("Invalid input, try again: ");
        }

        return num;
    }
}
