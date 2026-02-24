using System.Reflection;
using System.Text;

namespace AssemblyInfo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Assembly assembly = Assembly.GetExecutingAssembly();

            Console.WriteLine($"Збірка: {assembly.FullName}");
            Console.WriteLine($"Шлях:   {assembly.Location}");
            Console.WriteLine($"Версія середовища: {assembly.ImageRuntimeVersion}");

            // Виведемо всі класи, які ми створили в цій збірці
            Console.WriteLine("\nСписок типів у цій збірці:");
            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine($" -> Клас: {type.Name}");
            }

            // Отримуємо всі модулі цієї збірки
            Module[] modules = assembly.GetModules();

            foreach (Module m in modules)
            {
                Console.WriteLine($"--- Модуль: {m.Name} ---");
                Console.WriteLine($"Шлях: {m.FullyQualifiedName}");
                Console.WriteLine($"GUID (MVID): {m.ModuleVersionId}");

                // Можна дістати всі типи саме з цього модуля
                foreach (Type t in m.GetTypes())
                {
                    Console.WriteLine($"  Клас: {t.Name}");
                }
            }
        }
    }
}
