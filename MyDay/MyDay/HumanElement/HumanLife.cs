using MyDay.DayEvents;
using MyDay.EducationsPrograms;
using Autofac;

namespace MyDay.HumanElement;

public class HumanLife
{
    Autofac.ContainerBuilder builder;
    IContainer container;

    public HumanLife()
    {
        builder = new ContainerBuilder();
        
    }
    public void run()
    {
        
        matrixArchitecture();
        eduPrograms();
    }
    

    
    public void matrixArchitecture()
    {
        builder.RegisterType<HumanEntity>().As<HumanEntity>();
        builder.RegisterType<OperatorBuilder>().As<OperatorBuilder>();
        
        builder.RegisterType<KungFuProgram>().As<IKungFuProgram>();
        builder.RegisterType<HelicopterProgram>().As<IHelicopterProgram>();
        
        container = builder.Build();
    }
    
    
    public void eduPrograms()
    {

        
        HumanEntity trinity = container.Resolve<HumanEntity>();
        OperatorBuilder opBuilder = container.Resolve<OperatorBuilder>();
        
        trinity.AddEducationProgram("KungFu", container.Resolve<IKungFuProgram>());
        trinity.AddEducationProgram("Helicopter",container.Resolve<IHelicopterProgram>());
        
        trinity.EchoEducationPrograms();
    }
    
    
    public void humanLife()
    {
        WorkDayEvent workDayEvent = new WorkDayEvent();
        WeekEndDayEvent weekEndDayEvent = new WeekEndDayEvent();
        
        HumanEntity human = new HumanEntity(null);

        for (int i = 0; i < 7; i++)
        {
            if (i < 5) // Assuming 5 work days and 2 weekend days
            {
                human.SetDayEvent(workDayEvent);
            }
            else
            {
                human.SetDayEvent(weekEndDayEvent);
            }
            human.DoDayEvent();
        }
    }
}