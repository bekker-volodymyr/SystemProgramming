namespace TimerExample;

public class Program
{
    static void Main()
    {
        // Створення таймера з делегатом TimerCallback
        Timer timer = new Timer(new TimerCallback(TimerMethod));
        // Налаштування та запуск таймеру
        // Параметр 1: затримка перед першим виконанням методу (мс)
        // Параметр 2: інтервал між викликами методу (мс)
        timer.Change(2000, 500);
        // Тримаємо основний поток відкритим
        Console.ReadKey();
        // Ручне завершення таймеру
        timer.Dispose();
    }
    // Метод для виклику таймером в окремому потоці
    static void TimerMethod(object timer)
    {
        Console.WriteLine("This is one timer round!");
    }
}