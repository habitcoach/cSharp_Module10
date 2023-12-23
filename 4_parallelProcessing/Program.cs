using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        //Parallel.Invoke method doesn't return until all the provided actions (tasks) have completed.

        Parallel.Invoke(
            () => doCalculation("1"),
            () => doCalculation("2"),
            () => doCalculation("3")
        );

        Console.WriteLine("All tasks have completed.");
    }

    static void doCalculation(string s)
    {
        //for (int i = 0; i < 1000; i++)
        //{
        //    // some time-consuming operation here...
        //    Console.Write(s);
        //    Thread.Sleep(3000);
        //}

          Parallel.For(0, 1000, i => { Console.Write(s); Thread.Sleep(3000); });

        //paralle.for will run for in paralle hence it is bit faster than for

    }
}
