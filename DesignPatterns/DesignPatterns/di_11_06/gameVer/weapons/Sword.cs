namespace DesignPatterns.di_11_06.gameVer.weapons;

public class Sword : IWeapon
{
    public void Attack()
    {
        System.Console.WriteLine("Attacking with sword");
    }

    public void Defend()
    {
        System.Console.WriteLine("Defending with sword");
    }
}