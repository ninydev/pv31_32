namespace DesignPatterns.di_13_06;
using Autofac;

public class GamePad1306_autofac
{
    public static void run()
    {
        
        // 1. Настраиваем контейнер
        var builder = new ContainerBuilder();

        // Регистрируем зависимости
        builder.RegisterType<FireSword>().As<ISword>();
        builder.RegisterType<IceSword>().As<IIceSword>();
        builder.RegisterType<MyLogger>().As<ILoggerSystem>().SingleInstance();
        builder.RegisterType<Paladin>().AsSelf();
        builder.RegisterType<Barbarian>().AsSelf();

        var container = builder.Build();
        
        container.Resolve<Paladin>().Fight();
        container.Resolve<Barbarian>().Fight();
        
        
        // Создаем контейнер Ninject
        // IKernel kernel = new StandardKernel();
        //
        // kernel.Bind<ILoggerSystem>().To<MyLogger>().InSingletonScope();
        //
        // // Регистрация зависимостей
        // kernel.Bind<ISword>().To<FireSword>(); // Можно заменить на FireSword для тестирования
        // kernel.Bind<IIceSword>().To<IceSword>();
        // kernel.Bind<IFireSword>().To<FireSword>();
        //
        // // Получаем экземпляр Paladin с внедренной зависимостью
        // Paladin paladin = kernel.Get<Paladin>();
        // Barbarian barbarian = kernel.Get<Barbarian>();
        //
        // // Выполняем бой
        //
        //
        // paladin.Fight();
        // barbarian.Fight();
        //
        // paladin.ToIceSword(kernel.Get<IIceSword>());
        // paladin.Fight();
        //
        
        // Paladin paladin = new Paladin(new FireSword());
        // paladin.Fight();
    }
}