using System.Net;

namespace CallbackCancellationToken
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var cts = new CancellationTokenSource();
            var token = cts.Token;

            _ = Task.Run(async () =>
            {
                using var client = new WebClient();

                client.DownloadStringCompleted += (_, args) =>
                {
                    if (args.Cancelled)
                    {
                        Console.WriteLine("The download was canceled.");
                    }
                    else
                    {
                        Console.WriteLine("The download has completed:\n");

                        Console.WriteLine($"{args.Result}\n\nPress any key to continue.");
                    }
                };

                if (!token.IsCancellationRequested)
                {
                    using CancellationTokenRegistration ctr = token.Register(() => client.CancelAsync());

                    Console.WriteLine("Starting request\n");
                    await client.DownloadStringTaskAsync(new Uri("hhtp://www.contoso.com"));
                }
            }, token);

            Console.WriteLine("Press 'c' to cancel.\n\n");
            if (Console.ReadKey().KeyChar == 'c')
            {
                cts.Cancel();
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
