namespace DesignPatterns.di_13_06;

public class IceSword : ISword, IIceSword {
    public void Attack() => Console.WriteLine("❄️ Паладин наносит ледяной удар!");
}