namespace MyDay.EducationsPrograms;

public class OperatorBuilder
{
    public IEducationProgram Build(String name)
    {
        // Здесь можно реализовать логику для создания программы обучения оператора
        // Например, в зависимости от имени возвращать разные программы
        return name switch
        {
            "KungFu" => new KungFuProgram(),
            "Helicopter" => new HelicopterProgram(),
            _ => throw new ArgumentException("Неизвестная программа обучения", nameof(name))
        };
    }
}