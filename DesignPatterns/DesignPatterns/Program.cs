// See https://aka.ms/new-console-template for more information

using DesignPatterns;

Console.WriteLine("Hello, World!");

ConnectToRabbitMq conn =  ConnectToRabbitMq.Instance; //new ConnectToRabbitMq();

Car car1 = new Car();

Car car2 = CarBuilder.createCar();

CatWithBuilder cat = new CatWithBuilder()
    .SetName("Whiskers")
    .SetAge(3)
    .SetColor("Tabby");


