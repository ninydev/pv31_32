namespace DesignPatterns.pr1;

public class PersonModel
{
    
    private IPersonEcho _echo;
    
    public PersonModel SetEcho(IPersonEcho echo)
    {
        _echo = echo;
        return this;
    }

    public void Echo()
    {
        if (_echo != null)
        {
            _echo.EchoPerson(this);
        }
        else
        {
            throw new InvalidOperationException("Echo method is not set.");
        }
    }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public PersonModel(string name, string surname, DateTime dob, string email, string phoneNumber)
    {
        Name = name;
        Surname = surname;
        BirthDate = dob;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public PersonModel()
    {
        
    }
    
    public PersonModel SetName(string name)
    {
        Name = name;
        return this;
    }
    
    public PersonModel SetSurname(string surname)
    {
        Surname = surname;
        return this;
    }
    
    public PersonModel SetBirthDate(DateTime dob)
    {
        BirthDate = dob;
        return this;
    }
    
    public PersonModel SetEmail(string email)
    {
        Email = email;
        return this;
    }
    
    public PersonModel SetPhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
        return this;
    }

    
    // public override string ToString()
    // {
    //     return $"{Name} {Surname} - {Email} - {PhoneNumber}";
    // }
}