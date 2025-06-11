namespace DesignPatterns.di_11_06.gameVer.weapons;

public class Shield : IWeapon
{
    public void Attack()
    {
        System.Console.WriteLine("Attacking with shield");
    }

    public void Defend()
    {
        System.Console.WriteLine("Defending with shield");
    }
}