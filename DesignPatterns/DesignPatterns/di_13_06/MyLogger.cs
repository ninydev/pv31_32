namespace DesignPatterns.di_13_06;

public class MyLogger : ILoggerSystem
{
    public MyLogger()
    {
        System.Console.WriteLine("Создан MyLogger");
    }
    
    public void info(string message)
    {
        System.Console.WriteLine(message);
    }
}