using System.Diagnostics;

namespace StartCalculator_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Press enter to start calculator: ");
            _ = Console.ReadLine();

            Process calcProcess = new Process();

            calcProcess.StartInfo = new ProcessStartInfo("calc.exe");

            calcProcess.Start();

            Console.Write("Press enter to stop calculator: ");
            _ = Console.ReadLine();

            // Шукаємо реальні процеси калькулятора
            Process[] realCalcs = Process.GetProcessesByName("CalculatorApp");

            foreach (var p in realCalcs)
            {
                p.CloseMainWindow();

                if (!p.WaitForExit(2000))
                {
                    p.Kill();
                }
                p.Dispose();
            }
        }
    }
}
