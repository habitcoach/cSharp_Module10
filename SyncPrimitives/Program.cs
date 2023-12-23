using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    private static ManualResetEventSlim resourceLock = new ManualResetEventSlim(true); // Set initial state to signaled

    static void Main(string[] args)
    {
        Task[] tasks = new Task[3];

        for (int i = 0; i < tasks.Length; i++)
        {
            int threadId = i + 1;
            tasks[i] = Task.Run(() => UseResource(threadId));
        }

        Task.WaitAll(tasks);
    }

    static void UseResource(object threadId)
    {
        Console.WriteLine($"Thread {threadId} is waiting for the resource.");

        // Wait until the event is signaled
        resourceLock.Wait();

        lock (resourceLock)
        {
            Console.WriteLine($"Thread {threadId} has acquired the resource.");
            Thread.Sleep(1000); // Simulate some work
        }

        Console.WriteLine($"Thread {threadId} is releasing the resource.");
        resourceLock.Set(); // Signal the event, allowing the next waiting thread to proceed
    }
}
