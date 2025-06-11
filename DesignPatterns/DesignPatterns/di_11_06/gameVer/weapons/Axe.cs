namespace DesignPatterns.di_11_06.gameVer.weapons;

public class Axe : IWeapon
{
    public void Attack()
    {
        System.Console.WriteLine("Attacking with axe");
    }

    public void Defend()
    {
        System.Console.WriteLine("Defending with axe");
    }
}