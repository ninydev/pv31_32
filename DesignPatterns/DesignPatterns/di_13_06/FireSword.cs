namespace DesignPatterns.di_13_06;

public class FireSword :ISword
{
    public FireSword()
    {
        Console.WriteLine("🔥 Создан огненный меч!");
    }
    public void Attack() => Console.WriteLine("🔥 Паладин наносит огненный удар!");
}