﻿namespace TwoCancellationTokens
{
    public class Program
    {
        static void Main(string[] args)
        {
            WorkerWithTimer worker = new WorkerWithTimer();
            CancellationTokenSource cts = new CancellationTokenSource();

            // Task for UI thread, so we can call Task.Wait wait on the main thread.
            Task.Run(() =>
            {
                Console.WriteLine("Press 'c' to cancel within 3 seconds after work begins.");
                Console.WriteLine("Or let the task time out by doing nothing.");
                if (Console.ReadKey(true).KeyChar == 'c')
                    cts.Cancel();
            });

            // Let the user read the UI message.
            Thread.Sleep(1000);

            // Start the worker task.
            Task task = Task.Run(() => worker.DoWork(cts.Token), cts.Token);

            try
            {
                task.Wait(cts.Token);
            }
            catch (OperationCanceledException ex)
            {
                if (ex.CancellationToken == cts.Token)
                {
                    Console.WriteLine("Canceled from UI thread throwing OCE.");
                }
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"AggreagateException caught: {ex.InnerException}");
                foreach (var inner in ex.InnerExceptions)
                {
                    Console.WriteLine(inner.Message + inner.Source);
                }
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            cts.Dispose();
            worker.Dispose();
        }
    }

    class WorkerWithTimer
    {
        CancellationTokenSource internalTokenSource = new CancellationTokenSource();
        CancellationToken internalToken;
        CancellationToken externalToken;
        Timer timer;

        public WorkerWithTimer()
        {
            // A toy cancellation trigger that times out after 3 seconds
            // if the user does not press 'c'.
            timer = new Timer(new TimerCallback(CancelAfterTimeout), null, 3000, 3000);
        }

        public void DoWork(CancellationToken externalToken)
        {
            // Create a new token that combines the internal and external tokens.
            this.internalToken = internalTokenSource.Token;
            this.externalToken = externalToken;

            using (CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(internalToken, externalToken))
            {
                try
                {
                    DoWorkInternal(linkedCts.Token);
                }
                catch (OperationCanceledException ex)
                {
                    if (internalToken.IsCancellationRequested)
                    {
                        Console.WriteLine("Operation timed out.");
                    }
                    else if (externalToken.IsCancellationRequested)
                    {
                        Console.WriteLine("Cancelling per user request.");
                        externalToken.ThrowIfCancellationRequested();
                    }
                }
            }
        }

        private void DoWorkInternal(CancellationToken token)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (token.IsCancellationRequested)
                {
                    // We need to dispose the timer if cancellation
                    // was requested by the external token.
                    timer.Dispose();

                    // Throw the exception.
                    token.ThrowIfCancellationRequested();
                }

                // Simulating work.
                Thread.SpinWait(7500000);
                Console.Write("working... ");
            }
        }

        public void CancelAfterTimeout(object? state)
        {
            Console.WriteLine("\r\nTimer fired.");
            internalTokenSource.Cancel();
            timer.Dispose();
        }

        public void Dispose()
        {
            timer.Dispose();
            internalTokenSource.Dispose();
        }
    }
}

// Docs link: https://learn.microsoft.com/en-us/dotnet/standard/threading/how-to-listen-for-multiple-cancellation-requests