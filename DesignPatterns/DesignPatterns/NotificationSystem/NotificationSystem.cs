namespace DesignPatterns.NotificationSystem;

public class NotificationSystem
{
    private LinkedList<INotificationChannelInterface> _notificationChannels = new LinkedList<INotificationChannelInterface>();
    
    public NotificationSystem AddNotificationChannel(INotificationChannelInterface notificationChannel)
    {
        if (notificationChannel == null)
        {
            throw new ArgumentNullException(nameof(notificationChannel), "Notification channel cannot be null");
        }
        
        _notificationChannels.AddLast(notificationChannel);
        return this;
    }
    
    private static NotificationSystem _instance;
    public static NotificationSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new NotificationSystem();
            }
            return _instance;
        }
    }
    
    private NotificationSystem(){}
    
    // public NotificationSystem()
    // {
    //     _notificationChannels.AddLast(new SmsSender());
    //     _notificationChannels.AddLast(new EmailSender());
    //     
    // }

    public void Notify(NotificationModel notification)
    {
        if (notification == null)
        {
            throw new ArgumentNullException(nameof(notification), "Notification cannot be null");
        }

        // Here we can add more notification channels in the future
        foreach (var channel in _notificationChannels)
        {
            channel.Send(notification);
        }
        
        // Log the notification to console for demonstration purposes
        Console.WriteLine(notification.ToString());
    }
}