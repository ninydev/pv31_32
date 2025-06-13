namespace DesignPatterns.di_13_06;

public class MyBigProgram
{
    public static void run()
    {
        int a = 10;
        int b = 20;
        
        IMyBigService myBigService = new MyBigService();
        
        int result = myBigService.DoSomething(a, b);
        
        Console.WriteLine(result);
    }
}