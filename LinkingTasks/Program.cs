using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        //var firstTask = new Task<string>(() => "Hello");

        //var secondTask = firstTask.ContinueWith((p) =>
        //    ($"{p.Result}, World!"));

        //firstTask.Start();

        //Console.WriteLine(secondTask.Result);


        var outer = Task.Run(() =>
        {
            Console.WriteLine("Outer task starting…");
            var inner = Task.Run(() =>
            {
                Console.WriteLine("Nested task starting…");

                Thread.Sleep(2000);
                Console.WriteLine("Nested task completing…");
            });
            inner.Wait();
        });
       
        outer.Wait();
        Console.WriteLine("Outer task completed…");
        // Console.WriteLine("Outer task completed.");

        //// Thread.SpinWait(500000);

        //Console.ReadKey(); // Wait for a key press before exiting
    }
}
