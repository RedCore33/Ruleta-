using NUnit.Framework;
using System;

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
    public void Sum_MaxIntValues_ReturnsCorrectResult()
    {
        Assert.AreEqual(int.MaxValue, _calculator.Sum(int.MaxValue, 0));
        Assert.AreEqual(int.MinValue, _calculator.Sum(int.MinValue, 0));
    }

    [Test]
    public void Subtract_MaxIntValues_ReturnsCorrectResult()
    {
        Assert.AreEqual(int.MaxValue, _calculator.Subtract(int.MaxValue, 0));
        Assert.AreEqual(int.MinValue, _calculator.Subtract(int.MinValue, 0));
    }

    [Test]
    public void Multiply_ByZero_ReturnsZero()
    {
        Assert.AreEqual(0, _calculator.Multiply(12345, 0));
        Assert.AreEqual(0, _calculator.Multiply(0, 98765));
    }

    [Test]
    public void Divide_MaxIntValues_ReturnsCorrectResult()
    {
        Assert.AreEqual(1, _calculator.Divide(int.MaxValue, int.MaxValue));
        Assert.AreEqual(0, _calculator.Divide(0, int.MaxValue));
    }

    [Test]
    public void Divide_ByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(1, 0));
    }
}
