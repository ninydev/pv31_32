namespace DesignPatterns.di_11_06.decorator_example;

public class CacheDecorator :IRead
{
    private readonly IRead _readService;
    private string _cachedData;
    private int _cacheHits = 0;
    private readonly int ttl = 2;

    public CacheDecorator(IRead readService)
    {
        _readService = readService;
    }

    public string Read()
    {
        if (_cachedData == null || _cachedData == string.Empty || _cacheHits > ttl)
        {
            Console.WriteLine(" +++ Cache miss or ttl, reading from service...");
            _cacheHits = 0;
            _cachedData = _readService.Read();
        }
        else
        {
            Console.WriteLine("Cache hit, returning cached data...");
        }
        _cacheHits++;
        return _cachedData;
    }
}