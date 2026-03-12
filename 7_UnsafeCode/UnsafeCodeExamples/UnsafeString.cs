using System.Runtime.InteropServices;

namespace UnsafeCodeExamples
{
    public unsafe class UnsafeString : IDisposable
    {
        // Вказівник на початок масиву символів у некерованій пам'яті
        private char* _buffer;
        private readonly int _length;
        private bool _disposed = false;

        public int Length => _length;

        // Конструктор: виділяємо пам'ять та копіюємо дані
        public UnsafeString(string source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            _length = source.Length;

            // Виділяємо пам'ять у байтах: кількість символів * розмір char (2 байти)
            int sizeInBytes = _length * sizeof(char);
            _buffer = (char*)NativeMemory.Alloc((nuint)sizeInBytes);

            // Копіюємо дані з керованого рядка в наш некерований буфер
            fixed (char* sourcePtr = source)
            {
                Buffer.MemoryCopy(sourcePtr, _buffer, sizeInBytes, sizeInBytes);
            }

            Console.WriteLine($"[Log] Пам'ять виділена за адресою: {(long)_buffer:X}");
        }

        // Індексатор для швидкого доступу за вказівником
        public char this[int index]
        {
            get
            {
                if (index < 0 || index >= _length) throw new IndexOutOfRangeException();
                return _buffer[index]; // Прямий доступ до пам'яті
            }
            set
            {
                if (index < 0 || index >= _length) throw new IndexOutOfRangeException();
                _buffer[index] = value;
            }
        }

        // Перевантаження ToString для виводу
        public override string ToString()
        {
            return new string(_buffer, 0, _length);
        }

        // Деструктор (Finalizer) — спрацює, якщо розробник забув викликати Dispose
        ~UnsafeString()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Кажемо GC, що деструктор викликати вже не треба
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_buffer != null)
                {
                    NativeMemory.Free(_buffer); // Звільняємо пам'ять вручну!
                    Console.WriteLine("[Log] Некерована пам'ять успішно звільнена.");
                    _buffer = null;
                }
                _disposed = true;
            }
        }
    }
}
