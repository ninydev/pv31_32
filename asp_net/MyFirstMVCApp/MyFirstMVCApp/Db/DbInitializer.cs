using MyFirstMVCApp.Entities;

namespace MyFirstMVCApp.Db;

public class DbInitializer
{
    public static void Seed(SqLiteDbContext context)
    {
        if (!context.Manufacturers.Any())
        {
            context.Manufacturers.AddRange(
                new ManufacturerEntity 
                    { Name = "Toyota", 
                        SiteUrl = "https://www.toyota.com", 
                        LogoUrl = "" },
                new ManufacturerEntity { Name = "Ford", 
                    SiteUrl = "https://www.ford.com", 
                    LogoUrl = "" }
            );
            context.SaveChanges();
        }
    }
}