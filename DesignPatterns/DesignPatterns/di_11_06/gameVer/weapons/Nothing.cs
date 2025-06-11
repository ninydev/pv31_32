namespace DesignPatterns.di_11_06.gameVer.weapons;

public class Nothing : IWeapon
{
    public void Attack()
    {
        System.Console.WriteLine("Attacking with nothing");
    }

    public void Defend()
    {
        System.Console.WriteLine("Defending with nothing");
    }
}