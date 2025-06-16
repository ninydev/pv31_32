namespace DesignPatterns.di_13_06;

public class Paladin {
    private ISword _sword;
    private readonly ILoggerSystem _logger;

    public Paladin(ISword sword, ILoggerSystem logger) {
        _sword = sword;
        _logger = logger;
    }
    
    public void ToIceSword(IIceSword iceSword)
    {
        _sword = iceSword;
    }

    public void ToFireSword(IFireSword fireSword)
    {
        _sword = fireSword;
    }

    public void EquipSword(ISword sword)
    {
        _sword = sword;   
    }

    public void Fight() {
        _logger.info("Paladin is fighting with a sword.");
        _sword.Attack();
    }
}