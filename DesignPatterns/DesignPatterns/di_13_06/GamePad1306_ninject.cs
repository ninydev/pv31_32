namespace DesignPatterns.di_13_06;
using Ninject;

public class GamePad1306_ninject
{
    public static void run()
    {
        // Создаем контейнер Ninject
        IKernel kernel = new StandardKernel();
        // Регистрация зависимостей
        kernel.Bind<ISword>().To<FireSword>(); // Можно заменить на FireSword для тестирования
        // Получаем экземпляр Paladin с внедренной зависимостью
        Paladin paladin = kernel.Get<Paladin>();
        // Выполняем бой
        
        
        paladin.Fight();
        
        
        // Paladin paladin = new Paladin(new FireSword());
        // paladin.Fight();
    }
}