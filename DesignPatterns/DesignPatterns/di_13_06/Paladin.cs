namespace DesignPatterns.di_13_06;

public class Paladin {
    private readonly ISword _sword;
    private readonly ILoggerSystem _logger;

    public Paladin(ISword sword, ILoggerSystem logger) {
        _sword = sword;
        _logger = logger;
    }

    public void Fight() {
        _logger.info("Paladin is fighting with a sword.");
        _sword.Attack();
    }
}