using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Calculator;

[TestFixture]
public class IntegrationTests
{
    private Calculator _calculator;
    private MockUI _ui;
    private Logic _logic;
    private string _inputFilePath;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
        _ui = new MockUI();
        _logic = new Logic(_calculator, _ui);

        _inputFilePath = Path.Combine(Path.GetTempPath(), "test_input.txt");
    }

    [TearDown]
    public void Cleanup()
    {
        if (File.Exists(_inputFilePath))
            File.Delete(_inputFilePath);
    }

    [Test]
    public void Run_Addition_Subtract_Multiply_Divide_FromFile_WritesCorrectResults()
    {
        File.WriteAllLines(_inputFilePath, new[]
        {
            "1 2 3",
            "2 5 2",
            "3 2 4",
            "4 6 3" 
        });

        _ui.Inputs.Enqueue(_inputFilePath);
        _ui.Inputs.Enqueue("5");

        _logic.RunFromFile();

        Assert.IsTrue(_ui.Outputs.Any(line => line.Contains("Result: 5")), "Sum result missing");
        Assert.IsTrue(_ui.Outputs.Any(line => line.Contains("Result: 3")), "Subtract result missing");
        Assert.IsTrue(_ui.Outputs.Any(line => line.Contains("Result: 8")), "Multiply result missing");
        Assert.IsTrue(_ui.Outputs.Any(line => line.Contains("Result: 2")), "Divide result missing");
    }

    [Test]
    public void Run_Divide_ByZero_ShowsErrorMessage()
    {
        File.WriteAllLines(_inputFilePath, new[]
        {
            "4 5 0"
        });

        _ui.Inputs.Enqueue(_inputFilePath);
        _ui.Inputs.Enqueue("5");

        _logic.RunFromFile();

        Assert.IsTrue(_ui.Outputs.Any(line => line.Contains("Error")), "Divide by zero should show error");
    }
}

public class MockUI : IUserInterface
{
    public Queue<string> Inputs { get; } = new Queue<string>();
    public List<string> Outputs { get; } = new List<string>();

    public string Read() => Inputs.Dequeue();
    public void Write(string message) => Outputs.Add(message);
}
