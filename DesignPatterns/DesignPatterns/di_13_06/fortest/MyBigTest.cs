namespace DesignPatterns.di_13_06;

public class MyBigTest
{
    public static void run()
    {
        
        int [][] testCase = new int[][]
        {
            new int[] { 10, 20, 30 },
            new int[] { 5, 15, 20 },
            new int[] { 100, 200, 300 }
        };
        
        foreach (var test in testCase)
        {
            int a = test[0];
            int b = test[1];
            int expected = test[2];

            IMyBigService myBigService = new MyBigService();
            int result = myBigService.DoSomething(a, b);

            if (result == expected)
            {
                Console.WriteLine($"Test passed for inputs {a} and {b}. Expected: {expected}, Got: {result}");
            }
            else
            {
                Console.WriteLine($"Test failed for inputs {a} and {b}. Expected: {expected}, Got: {result}");
            }
        }
    }
}