namespace DesignPatterns.di_13_06;

public class Paladin {
    private readonly ISword _sword;

    public Paladin(ISword sword) {
        _sword = sword;
    }

    public void Fight() {
        Console.Write("Паладин вступает в бой... ");
        _sword.Attack();
    }
}