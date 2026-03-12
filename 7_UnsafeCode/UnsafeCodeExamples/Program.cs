namespace UnsafeCodeExamples
{
    public class Program
    {
        unsafe static void SquareParam(int* p)
        {
            *p *= *p;
        }

        unsafe static void Main(string[] args)
        {
            int num = 5;

            SquareParam(&num);
            Console.WriteLine(num);
        }

        public static int FindFirstIndex(char[] data, char target)
        {
            // 1. Звичайна safe-частина: валідація
            if (data == null || data.Length == 0) return -1;

            // 2. Unsafe-блок
            unsafe
            {
                fixed (char* pStart = data)
                {
                    char* ptr = pStart;
                    char* pEnd = pStart + data.Length;

                    while (ptr < pEnd)
                    {
                        if (*ptr == target)
                        {
                            // Обчислюємо індекс через різницю адрес
                            // (адреса поточного елемента - адреса початку)
                            return (int)(ptr - pStart);
                        }
                        ptr++;
                    }
                }
            }

            // 3. Знову safe-частина
            return -1;
        }

        unsafe void StackAllocUnsafe()
        {
            // Виділяємо 100 елементів на стеку
            int* ptr = stackalloc int[100];

            for (int i = 0; i < 100; i++)
            {
                *(ptr + i) = i; // Арифметика вказівників
            }
            // Ризик: можна випадково вийти за межі ptr + 100
        }

        void StackAllocSafe()
        {
            Span<int> buffer = stackalloc int[100];

            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = i;
            }
            // Span сам викине IndexOutOfRangeException при помилці
        }
    }
}
