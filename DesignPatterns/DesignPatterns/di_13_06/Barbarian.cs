namespace DesignPatterns.di_13_06;

public class Barbarian {
    private readonly ISword _sword;
    private readonly ILoggerSystem _logger;

    public Barbarian(ISword sword , ILoggerSystem logger) {
        _sword = sword;
        _logger = logger;
    }

    public void Fight() {
        _logger.info("Barbarian is fighting with a sword.");
        _sword.Attack();
    }
}