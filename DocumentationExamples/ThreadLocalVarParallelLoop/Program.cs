namespace ThreadLocalVarParallelLoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Enumerable.Range(0, 1_000_000).ToArray();
            long total = 0;

            // Use type parameter to make subtotal a long, not an int
            Parallel.For<long>(0, nums.Length, () => 0,
                (j, loop, subtotal) =>
                {
                    subtotal += nums[j];
                    return subtotal;
                },
                subtotal => Interlocked.Add(ref total, subtotal));

            Console.WriteLine($"The total is {total:N0}");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}

// Docs link: https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-write-a-parallel-for-loop-with-thread-local-variables#example