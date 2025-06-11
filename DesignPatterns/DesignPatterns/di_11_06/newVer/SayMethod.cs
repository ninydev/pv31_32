namespace DesignPatterns.di_11_06.newVer;

public class SayMethod : ISayNew
{
    private string _world;
    public SayMethod(string world)
    {
        _world = world;
    }
    
    public void Say()
    {
        System.Console.WriteLine(_world);
    }
}