namespace DesignPatterns.NotificationSystem;

public class EmailSender : INotificationChannelInterface
{

    public void Send(NotificationModel notification)
    {
        Console.WriteLine($"Sending email title {notification.Title}");
    }
}