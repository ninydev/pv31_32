using MyDay.DayEvents;
using MyDay.EducationsPrograms;

namespace MyDay.HumanElement;

public class HumanEntity
{
    
    private Dictionary<String, IEducationProgram> educationPrograms 
            = new Dictionary<String, IEducationProgram>();
    
    public void AddEducationProgram(String name, IEducationProgram program)
    {
        if (!educationPrograms.ContainsKey(name))
        {
            educationPrograms[name] = program;
        }
    }
    
    public void EchoEducationPrograms()
    {
        foreach (var program in educationPrograms)
        {
            Console.WriteLine($"Program Name: {program.Key}");
            program.Value.EchoNameProgram();
        }
    }
    
    public void useEducationProgram(String name)
    {
        if (educationPrograms.ContainsKey(name))
        {
            educationPrograms[name].EchoNameProgram();
        }
        else
        {
            Console.WriteLine($"Программа с именем {name} не найдена.");
        }
    }
    
    
    
    private Guid id = Guid.NewGuid();
    
    IDayEvent dayEvent;
    public HumanEntity(IDayEvent dayEvent)
    {
        this.dayEvent = dayEvent;
    }
    
    public void DoDayEvent()
    {
        dayEvent.DoDayEvent();
    }
    
    public void SetDayEvent(IDayEvent newDayEvent)
    {
        dayEvent = newDayEvent;
    }
}