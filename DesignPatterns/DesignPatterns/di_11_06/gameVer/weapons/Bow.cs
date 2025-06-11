namespace DesignPatterns.di_11_06.gameVer.weapons;

public class Bow : IWeapon
{
    public void Attack()
    {
        System.Console.WriteLine("Attacking with bow");
    }

    public void Defend()
    {
        System.Console.WriteLine("Defending with bow");
    }
}