using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken ct = cts.Token;

        var task1 = Task.Run<double>(() => doCalculation(ct));

        int completedTask =  Task.WaitAny(task1, Task.Delay(3000));  //return the index of finished task

        if (completedTask == 1)
        {
            // The task was canceled or didn't complete in time
            cts.Cancel();
            Console.WriteLine("Task canceled");
        }
        else
        {
            Console.WriteLine("Task result: " + task1.Result);
        }
    }

    static double doCalculation(CancellationToken ct)
    {
        double result = 0.0;

        Console.Write("Processing:");

        for (int i = 0; i < 1000; i++)
        {
            // some time-consuming operation here...
            result += Math.Sqrt(i);
            Thread.Sleep(100);
            Console.Write(".");

            if (ct.IsCancellationRequested) return 0.0;
        }

        return result;
    }
}
