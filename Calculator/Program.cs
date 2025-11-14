using System;

class Program
{
    static void Main()
    {
        var calculator = new Calculator();
        var ui = new ConsoleInterface();
        var programLogic = new Logic(calculator, ui);
        programLogic.Run();
    }
}
