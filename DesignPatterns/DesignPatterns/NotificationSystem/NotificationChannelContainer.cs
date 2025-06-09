namespace DesignPatterns.NotificationSystem;

public class NotificationChannelContainer
{
    public static INotificationChannelInterface createNotificationChannel(NotificationChannelTypesEnum channelType)
    {
        return channelType switch
        {
            NotificationChannelTypesEnum.Email => new EmailSender(),
            NotificationChannelTypesEnum.Sms => new SmsSender(),
            _ => throw new ArgumentOutOfRangeException(nameof(channelType), $"No notification channel found for type {channelType}")
        };
    }
}