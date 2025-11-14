using NUnit.Framework;
using static Calculator;

[TestFixture]
public class SystemTests
{
    [Test]
    public void FullScenario_AllOperations()
    {
        var calculator = new Calculator();
        var ui = new MockUI();

        ui.Inputs.Enqueue("1"); ui.Inputs.Enqueue("2"); ui.Inputs.Enqueue("3");
        ui.Inputs.Enqueue("3"); ui.Inputs.Enqueue("2"); ui.Inputs.Enqueue("3");
        ui.Inputs.Enqueue("4"); ui.Inputs.Enqueue("6"); ui.Inputs.Enqueue("2");
        ui.Inputs.Enqueue("5");

        var logic = new Logic(calculator, ui);
        logic.Run();

        Assert.IsTrue(ui.Outputs.Exists(o => o.Contains("Result: 5")));
        Assert.IsTrue(ui.Outputs.Exists(o => o.Contains("Result: 6")));
        Assert.IsTrue(ui.Outputs.Exists(o => o.Contains("Result: 3")));
    }
}
