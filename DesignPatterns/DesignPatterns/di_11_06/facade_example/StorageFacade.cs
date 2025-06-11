namespace DesignPatterns.di_11_06.facade_example;

public class StorageFacade : IReadFile
{
    private readonly HashSet<IReadFile> _readFiles = new();
    private IReadFile _currentReader = null;

    public StorageFacade()
    {
    }
    public void AddReader(IReadFile reader)
    {
        _readFiles.Add(reader);
    }
    
    public string ReadFrom(int index)
    {
        if (index < 0 || index >= _readFiles.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        return _readFiles.ElementAt(index).Read();
    }
    
    public void SetCurrentReader(IReadFile reader)
    {
        _readFiles.Add(reader);
        _currentReader = reader;
    }

    public string Read()
    {
        if (_currentReader == null)
        {
            throw new InvalidOperationException("No current reader set.");
        }
        
        return _currentReader.Read();
    }
}