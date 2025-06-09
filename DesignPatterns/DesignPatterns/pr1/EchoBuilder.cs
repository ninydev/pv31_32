namespace DesignPatterns.pr1;

public class EchoBuilder
{
    public static IPersonEcho CreateEcho(EchoTypeEnum echoType)
    {
        return echoType switch
        {
            EchoTypeEnum.Full => new EchoFull(),
            EchoTypeEnum.Small => new EchoSmall(),
            _ => throw new ArgumentOutOfRangeException(nameof(echoType), echoType, null)
        };
    }
}