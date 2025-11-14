using NUnit.Framework;
using static Calculator;
using System.Collections.Generic;

[TestFixture]
public class IntegrationTests
{
    private Calculator _calculator;
    private MockUI _ui;
    private Logic _logic;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
        _ui = new MockUI();
        _logic = new Logic(_calculator, _ui);
    }

    [Test]
    public void Run_Addition_WritesCorrectResult()
    {
        _ui.Inputs.Enqueue("1");
        _ui.Inputs.Enqueue("2");
        _ui.Inputs.Enqueue("3");
        _ui.Inputs.Enqueue("5");

        _logic.Run();

        Assert.IsTrue(_ui.Outputs.Any(line => line.Contains("Result: 5")));
    }
}

public class MockUI : IUserInterface
{
    public Queue<string> Inputs { get; } = new Queue<string>();
    public List<string> Outputs { get; } = new List<string>();

    public string Read() => Inputs.Dequeue();
    public void Write(string message) => Outputs.Add(message);
}
