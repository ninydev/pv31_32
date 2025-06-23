namespace MyDay.DayEvents;

public class WeekEndDayEvent: IDayEvent
{
    public void DoDayEvent()
    {
        // Здесь можно реализовать логику для выходного дня
        // Например, вывод сообщения о начале выходного дня
        Console.WriteLine("Сегодня выходной день. Отдыхаем и наслаждаемся!");
    }
}