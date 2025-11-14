using System;

public interface IUserInterface
{
    void Write(string message);
    string Read();
}

public class ConsoleInterface : IUserInterface
{
    public void Write(string message) => Console.Write(message);
    public string Read() => Console.ReadLine();
}
