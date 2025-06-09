namespace DesignPatterns;

public class CatWithBuilder
{
    public CatWithBuilder()
    {
        
    }
    
    private string name;
    private int age;
    private string color;
    
    public CatWithBuilder SetName(string name)
    {
        this.name = name;
        return this;
    }
    
    public CatWithBuilder SetAge(int age)
    {
        this.age = age;
        return this;
    }
    
    public CatWithBuilder SetColor(string color)
    {
        this.color = color;
        return this;
    }
    
    public static CatWithBuilder create()
    {
        return new CatWithBuilder();
    }
    
}