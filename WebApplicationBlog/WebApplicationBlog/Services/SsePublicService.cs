using System.Text;

namespace WebApplicationBlog.Services;

public class SsePublicService
{
    private readonly Dictionary<Guid, StreamWriter> _clients = new();
    private readonly object _lock = new();

    // Добавить нового клиента
    public void AddClient(Guid clientId, Stream stream)
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