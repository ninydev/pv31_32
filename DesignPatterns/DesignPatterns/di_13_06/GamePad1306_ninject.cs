namespace DesignPatterns.di_13_06;
using Ninject;

public class GamePad1306_ninject
{
    public static void run()
    {
        // Создаем контейнер Ninject
        IKernel kernel = new StandardKernel();
        
        kernel.Bind<ILoggerSystem>().To<MyLogger>().InSingletonScope();
        
        // Регистрация зависимостей
        kernel.Bind<ISword>().To<FireSword>(); // Можно заменить на FireSword для тестирования
        // Получаем экземпляр Paladin с внедренной зависимостью
        Paladin paladin = kernel.Get<Paladin>();
        Barbarian barbarian = kernel.Get<Barbarian>();
        
        // Выполняем бой
        
        
        paladin.Fight();
        barbarian.Fight();
        
        
        // Paladin paladin = new Paladin(new FireSword());
        // paladin.Fight();
    }
}