using NUnit.Framework;
using static Calculator;

[TestFixture]
public class SmokeTests
{
    [Test]
    public void ProgramLogic_Run_DoesNotCrash()
    {
        var calculator = new Calculator();
        var ui = new MockUI();

        ui.Inputs.Enqueue("5");
        var logic = new Logic(calculator, ui);

        Assert.DoesNotThrow(() => logic.Run());
    }
}
