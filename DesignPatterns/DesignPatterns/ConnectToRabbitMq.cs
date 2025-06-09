namespace DesignPatterns;

public class ConnectToRabbitMq
{
    private ConnectToRabbitMq()
    {
        
    }
    
    private static ConnectToRabbitMq? _instance;
    public static ConnectToRabbitMq Instance
    {
        get { return _instance ?? (_instance = new ConnectToRabbitMq()); }
    }
    
    
}