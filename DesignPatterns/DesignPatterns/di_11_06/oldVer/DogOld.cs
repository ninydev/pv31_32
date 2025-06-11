namespace DesignPatterns.di_11_06.oldVer;

public class DogOld : AnimalOld, ISayOld
{
    public void Say()
    {        
        System.Console.WriteLine("Woof");
    }
}