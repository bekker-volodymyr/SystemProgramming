namespace PartitionLocalVarParallelForEach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Enumerable.Range(0, 1_000_000).ToArray();
            long total = 0;

            // First type parameter is the type of the source elements
            // Second type parameter is the type of the thread-local variable (partition subtotal)
            Parallel.ForEach<int, long>(
                nums, // source collection
                () => 0, // method to initialize the local variable
                (j, loop, subtotal) => // method invoked by the loop on each iteration
                {
                    subtotal += j; //modify local variable
                    return subtotal; // value to be passed to next iteration
                },
                // Method to be executed when each partition has completed.
                // finalResult is the final value of subtotal for a particular partition.
                (finalResult) => Interlocked.Add(ref total, finalResult));

            Console.WriteLine($"The total from Parallel.ForEach is {total:N0}");
        }
    }
}

// Docs link: https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-write-a-parallel-foreach-loop-with-partition-local-variables#example
