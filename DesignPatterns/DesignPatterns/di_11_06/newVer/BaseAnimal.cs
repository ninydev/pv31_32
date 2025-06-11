namespace DesignPatterns.di_11_06.newVer;

public class BaseAnimal : ISayNew
{
    
    private ISayNew _sayNew;

    public BaseAnimal(ISayNew sayNew)
    {
        _sayNew = sayNew;
    }
    
    public void Say()
    {
        _sayNew.Say();
    }
}