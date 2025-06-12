namespace DesignPatterns.di_12_06;

public class Lamp : IRoom, ILed
{
public    static Lamp Instance { get; } = new Lamp();

}