using System.Reflection;

namespace LoadAssembly
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Assembly asm = Assembly.LoadFrom("PersonLibrary.dll");

            // отримуємо необхідний модуль цієї збірки
            Module? mod = asm.GetModule("PersonLibrary.dll");

            if(mod == null)
            {
                Console.WriteLine("Error loading module.");
                return;
            }

            // виводимо список типів даних, оголошений у поточному модулі
            Console.WriteLine("Оголошені типи даних:");
            foreach (Type t in mod.GetTypes())
                Console.WriteLine(t.FullName);

            // отримуємо тип даних зі складання
            Type? personType = mod.GetType("PersonLibrary.Person") as Type;

            if(personType == null)
            {
                Console.WriteLine("Error loading module.");
                return;
            }

            // створюємо об'єкт отриманого типу даних
            object? person = Activator.CreateInstance(personType, new object[] { "Іван", "Іванов", 30 });

            // викликаємо метод Print від створеного об'єкту
            personType?.GetMethod("Print")?.Invoke(person, null);
        }
    }
}
