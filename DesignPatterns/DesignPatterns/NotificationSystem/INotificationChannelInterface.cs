namespace DesignPatterns.NotificationSystem;

public interface INotificationChannelInterface
{
    public void Send(NotificationModel notification);
}