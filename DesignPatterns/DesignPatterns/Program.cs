// See https://aka.ms/new-console-template for more information

using DesignPatterns;
using DesignPatterns.NotificationSystem;

// NotificationSystem notificationSystem = new NotificationSystem();

NotificationSystem notificationSystem = NotificationSystem.Instance
    .AddNotificationChannel(NotificationChannelContainer.createNotificationChannel(NotificationChannelTypesEnum.Email))
    .AddNotificationChannel(NotificationChannelContainer.createNotificationChannel(NotificationChannelTypesEnum.Sms));

NotificationModel notification = new NotificationModel("Test Notification", "This is a test message for the notification system.");
notificationSystem.Notify(notification);



