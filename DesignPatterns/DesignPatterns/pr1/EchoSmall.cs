namespace DesignPatterns.pr1;

public class EchoSmall : IPersonEcho
{
    public void EchoPerson(PersonModel person)
    {
        Console.WriteLine("Small version ---------------------------------");
        Console.WriteLine($"Name: {person.Name}");
        Console.WriteLine($"Surname: {person.Surname}");
        // Email and Phone Number are not echoed in this small version
        // Console.WriteLine($"Birth Date: {person.BirthDate.ToShortDateString()}");
        // Console.WriteLine($"Email: {person.Email}");
        // Console.WriteLine($"Phone Number: {person.PhoneNumber}");
    }
}