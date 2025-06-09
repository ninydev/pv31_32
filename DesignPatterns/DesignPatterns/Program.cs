// See https://aka.ms/new-console-template for more information

using DesignPatterns;
using DesignPatterns.NotificationSystem;
using DesignPatterns.pr1;


PersonModel person = PersonBuilder.createPerson()
    .SetName("John")
    .SetSurname("Doe")
    .SetBirthDate(new DateTime(1990, 1, 1))
    .SetEmail("no@email.com")
    .SetPhoneNumber("1234567890");

Console.WriteLine(person);

// Console.WriteLine(person.Name + " " + person.Surname + " - " + person.Email + " - " + person.PhoneNumber);

IPersonEcho echoFull = EchoBuilder.CreateEcho(EchoTypeEnum.Full);
person.SetEcho(echoFull);
person.Echo();

IPersonEcho echoSmall = EchoBuilder.CreateEcho(EchoTypeEnum.Small);
person.SetEcho(echoSmall);
person.Echo();

// NotificationSystem notificationSystem = new NotificationSystem();

// NotificationSystem notificationSystem = NotificationSystem.Instance
//     .AddNotificationChannel(NotificationChannelContainer.createNotificationChannel(NotificationChannelTypesEnum.Email))
//     .AddNotificationChannel(NotificationChannelContainer.createNotificationChannel(NotificationChannelTypesEnum.Sms));
//
// NotificationModel notification = new NotificationModel("Test Notification", "This is a test message for the notification system.");
// notificationSystem.Notify(notification);



