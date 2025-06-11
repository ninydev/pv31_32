namespace DesignPatterns.di_11_06.facade_example;

public class FacadeExample
{
    public static void run()
    {
        FtpRead ftpRead = new FtpRead();
        CloudRead cloudRead = new CloudRead();
        
        StorageFacade storageFacade = new StorageFacade();
        storageFacade.AddReader(ftpRead);
        storageFacade.AddReader(cloudRead);
        
        storageFacade.SetCurrentReader(ftpRead);
        Console.WriteLine(storageFacade.Read());
        
        storageFacade.SetCurrentReader(cloudRead);
        Console.WriteLine(storageFacade.Read());
        
        Console.WriteLine(storageFacade.ReadFrom(0));
        Console.WriteLine(storageFacade.ReadFrom(1));

        
        
    }
}