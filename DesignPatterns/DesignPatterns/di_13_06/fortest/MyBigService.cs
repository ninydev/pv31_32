namespace DesignPatterns.di_13_06;

public class MyBigService : IMyBigService
{
    public int DoSomething(int a, int b)
    {
        if (a == 100)
        {
            return 0;
        }
        return a + b;
    }
}