namespace DesignPatterns.NotificationSystem;

public class SmsSender : INotificationChannelInterface
{

    public void Send(NotificationModel notification)
    {
        Console.WriteLine($"Sending SMS title {notification.Title}");
    }
}