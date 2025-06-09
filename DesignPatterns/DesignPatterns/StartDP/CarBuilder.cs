namespace DesignPatterns;

public class CarBuilder
{
    public static Car createCar()
    {
        Console.WriteLine("Car created - using builder");
        Console.WriteLine("I control the creation of the car");
        Car  c =  new Car();
        c.color = "green";
        return c;
    }
}