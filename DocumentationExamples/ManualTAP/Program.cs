namespace ManualTAP
{
    public class Program
    {
        public static Task<int> ReadTask(Stream stream, byte[] buffer, int offset, int count, object state)
        {
            var tcs = new TaskCompletionSource<int>();
            stream.BeginRead(buffer, offset, count, ar =>
            {
                try { tcs.SetResult(stream.EndRead(ar)); }
                catch (Exception ex) { tcs.SetException(ex); }
            }, state);
            return tcs.Task;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
