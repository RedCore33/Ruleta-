using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace PPS_Ruleta.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void GirarRuletaAnimacion_ReturnsValidTuple()
        {
            // Arrange: get non-public static method via reflection
            var programType = typeof(Program);
            var method = programType.GetMethod(
                "GirarRuletaAnimacion",
                BindingFlags.NonPublic | BindingFlags.Static);

            Assert.NotNull(method);

            // Redirect console to avoid noisy output during test
            var originalOut = Console.Out;
            try
            {
                Console.SetOut(TextWriter.Null);

                // Act
                var result = method!.Invoke(null, null);

                // Assert structure and invariants
                Assert.NotNull(result);

                // The method returns a ValueTuple<int, string, string>
                var tuple = ((int resultado, string color, string paridad))result!;

                Assert.InRange(tuple.resultado, 0, 36);

                // Color mapping: 0 = Verde; even (>0) = Gris; odd = Rojo
                var expectedColor = tuple.resultado == 0 ? "Verde" : (tuple.resultado % 2 == 0 ? "Gris" : "Rojo");
                Assert.Equal(expectedColor, tuple.color);

                // Parity mapping: even (including 0) = Par; odd = Impar
                var expectedParidad = (tuple.resultado % 2 == 0) ? "Par" : "Impar";
                Assert.Equal(expectedParidad, tuple.paridad);
            }
            finally
            {
                Console.SetOut(originalOut);
            }
        }
    }
}

