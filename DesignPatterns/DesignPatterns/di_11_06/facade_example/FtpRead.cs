namespace DesignPatterns.di_11_06.facade_example;

public class FtpRead : IReadFile
{
    public string Read()
    {
        return "Read from ftp";
    }
}