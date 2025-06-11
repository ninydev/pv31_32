namespace DesignPatterns.di_11_06.decorator_example;

public class DecoratorExample
{
    public static void run()
    {
        IRead dbService = new DbService();
        IRead cacheDecorator = new CacheDecorator(dbService);
        
        string data = cacheDecorator.Read();
        Console.WriteLine(data);
        
        Console.WriteLine("--------- Reading again to test cache ---------");

        Console.WriteLine(cacheDecorator.Read());
        Console.WriteLine(cacheDecorator.Read());
        Console.WriteLine(cacheDecorator.Read());
        Console.WriteLine(cacheDecorator.Read());
    }
}