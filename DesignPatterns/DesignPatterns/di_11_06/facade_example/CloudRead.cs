namespace DesignPatterns.di_11_06.facade_example;

public class CloudRead : IReadFile
{
    public string Read()
    {
        return "Read from Cloud";
    }
}