using NUnit.Framework;
using static Calculator;

[TestFixture]
public class UnitTests
{
    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Sum_ReturnsCorrectResult()
    {
        Assert.AreEqual(5, _calculator.Sum(2, 3));
    }

    [Test]
    public void Subtract_ReturnsCorrectResult()
    {
        Assert.AreEqual(1, _calculator.Subtract(3, 2));
    }

    [Test]
    public void Multiply_ReturnsCorrectResult()
    {
        Assert.AreEqual(6, _calculator.Multiply(2, 3));
    }

    [Test]
    public void Divide_ReturnsCorrectResult()
    {
        Assert.AreEqual(2, _calculator.Divide(6, 3));
    }

    [Test]
    public void Divide_ByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(1, 0));
    }
}
