namespace MyDay.DayEvents;

public class WorkDayEvent: IDayEvent
{
    public void DoDayEvent()
    {
        // Здесь можно реализовать логику для рабочего дня
        // Например, вывод сообщения о начале рабочего дня
        Console.WriteLine("Сегодня рабочий день. Начинаем работать!");
    }
}