using System.Text;

namespace WebApplicationBlog.Services;

class SseClient
{
    public Guid UserId { get; } // Идентификатор пользователя
    public Guid ClientId { get; } // Идентификатор клиента (открытого окна, устройства и т.д.)
    public StreamWriter Writer { get; } // Поток для записи данных в клиент

    public SseClient(Guid userId, Guid clientId, Stream stream)
    {
        UserId = userId;
        ClientId = clientId;
        Writer = new StreamWriter(stream, Encoding.UTF8, leaveOpen: true);
    }
}

public class SsePrivateService
{
    private readonly Dictionary<Guid, StreamWriter> _clientsByUserId = new();
    private readonly Dictionary<Guid, StreamWriter> _clients = new();
    private readonly object _lock = new();

    // Добавить нового клиента
    public void AddClient(Guid userId, Guid clientId, Stream stream)
    {
        var writer = new StreamWriter(stream, leaveOpen: true);
        lock (_lock)
        {
            _clients[clientId] = writer;
        }
    }

    // Удалить клиента
    public void RemoveClient(Guid clientId)
    {
        lock (_lock)
        {
            if (_clients.TryGetValue(clientId, out var writer))
            {
                writer.Dispose();
                _clients.Remove(clientId);
            }
        }
        SendMessageToAllAsync("Клиент отключился: " + clientId).GetAwaiter().GetResult();
    }

    // Отправить сообщение всем клиентам
    public async Task SendMessageToAllAsync(string message)
    {
        List<Guid> disconnectedClients = new();
        lock (_lock)
        {
            foreach (var (clientId, writer) in _clients)
            {
                try
                {
                    writer.WriteLine($"data: {message}\n");
                    writer.Flush();
                }
                catch
                {
                    disconnectedClients.Add(clientId);
                }
            }
        }

        // Удаляем отключившихся клиентов
        foreach (var clientId in disconnectedClients)
        {
            RemoveClient(clientId);
        }
    }
}