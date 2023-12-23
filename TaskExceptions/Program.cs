using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var outer = Task.Run(() =>
            {
                Console.WriteLine("Outer task starting…");
                try
                {
                    var inner = Task.Run(() =>
                    {
                        Console.WriteLine("Nested task starting…");
                        Thread.SpinWait(500000);

                        Console.WriteLine("Nested task completing…");

                        throw new InvalidCastException("This is thown from inner task");
                    });

                    inner.Wait(); // Wait for the inner task to complete
                }

                catch (Exception ex) // Catch any exception, not just InvalidCastException
                {
                    Console.WriteLine("exception caught in inner exception");
                    throw; // Rethrow the caught exception
                }
            });

            outer.Wait(); // Wait for the outer task to complete

            Console.WriteLine("Outer task completed.");
        }
        catch (AggregateException ex)
        {
            foreach (var inner in ex.InnerExceptions)
            {
                Console.WriteLine(inner.Message);
            }
        }

        Console.ReadKey(); // Wait for a key press before exiting
    }
}
