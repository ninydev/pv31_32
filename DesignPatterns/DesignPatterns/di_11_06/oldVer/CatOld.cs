namespace DesignPatterns.di_11_06.oldVer;

public class CatOld : AnimalOld, ISayOld
{
    public void Say()
    {
        System.Console.WriteLine("Meow");
    }
    
}