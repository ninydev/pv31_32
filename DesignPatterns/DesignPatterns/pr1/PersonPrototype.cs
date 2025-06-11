namespace DesignPatterns.pr1;

public class PersonPrototype
{
    public PersonModel Clone(PersonModel person)
    {
        if (person == null)
        {
            throw new ArgumentNullException(nameof(person), "Person cannot be null");
        }

        // Create a new instance of PersonModel and copy properties
        return new PersonModel
        {
            Name = person.Name,
            Surname = person.Surname,
            BirthDate = person.BirthDate,
            Email = person.Email,
            PhoneNumber = person.PhoneNumber
        };
        
    }
}