namespace DesignPatterns.pr1;

public class EchoFull : IPersonEcho
{
    public void EchoPerson(PersonModel person)
    {
        Console.WriteLine("Full version ---------------------------------");
        Console.WriteLine($"Name: {person.Name}");
        Console.WriteLine($"Surname: {person.Surname}");
        Console.WriteLine($"Birth Date: {person.BirthDate.ToShortDateString()}");
        Console.WriteLine($"Email: {person.Email}");
        Console.WriteLine($"Phone Number: {person.PhoneNumber}");
        Console.WriteLine("---------------------------------\n");
    }
}