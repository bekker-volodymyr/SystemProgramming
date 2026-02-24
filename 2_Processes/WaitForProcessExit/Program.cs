using System.Diagnostics;

namespace WaitForProcessExit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Оголошуємо об'єкт класу Process
            Process proc = new Process();

            // встановлюємо ім'я файлу, який буде запущено в рамках процесу
            proc.StartInfo.FileName = "notepad.exe";

            // запускаємо процес
            proc.Start();

            // виводимо ім'я процесу
            Console.WriteLine("Процес розпочато: " + proc.ProcessName);

            // очікуємо на ззакриття процесу
            proc.WaitForExit();

            // виводимо код, з яким завершився процес
            Console.WriteLine("Процес завершився з кодом: " + proc.ExitCode);

            // виводимо ім'я поточного процесу
            Console.WriteLine("Поточний процес має ім'я: " + Process.GetCurrentProcess().ProcessName);
        }
    }
}
