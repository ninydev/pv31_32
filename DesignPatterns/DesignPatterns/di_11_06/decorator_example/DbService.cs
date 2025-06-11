namespace DesignPatterns.di_11_06.decorator_example;

public class DbService : IRead
{
    public string Read()
    {
        System.Console.WriteLine("Start read from database");
        Thread.Sleep(2000);
        System.Console.WriteLine("End read from database");
        return "Data from database";
    }
}