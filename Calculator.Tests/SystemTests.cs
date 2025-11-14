using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

[TestFixture]
public class SystemTests
{
    private string _exePath;

    [SetUp]
    public void Setup()
    {
        _exePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Calculator.dll");
    }

    [Test]
    public void FullScenario_AllOperations_E2E()
    {
        string[] inputs = { "1", "2", "3", "2", "3", "3", "3", "2", "5", "4", "4", "4", "5" };

        var psi = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = $"\"{_exePath}\"",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process { StartInfo = psi };
        process.Start();

        using (var writer = process.StandardInput)
        {
            foreach (var input in inputs)
            {
                writer.WriteLine(input);
            }

            writer.Close();
        }

        string output = process.StandardOutput.ReadToEnd();

        Assert.IsTrue(output.Contains("Result: 5"), "Sum result missing");
        Assert.IsTrue(output.Contains("Result: 0"), "Subtract result missing");
        Assert.IsTrue(output.Contains("Result: 10"), "Multiply result missing");
        Assert.IsTrue(output.Contains("Result: 1"), "Divide result missing");
    }
}
