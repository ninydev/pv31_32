namespace DesignPatterns.NotificationSystem;

public class NotificationModel
{
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }

    public NotificationModel(string title, string message)
    {
        Title = title;
        Message = message;
        Timestamp = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{Timestamp}: {Title} - {Message}";
    }
}