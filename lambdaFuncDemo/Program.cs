
using System;

public delegate int SumDelegate(int x, int y);
class Program
{
    static void Main(string[] args)
    {
        //normal delegare example
        SumDelegate sumdelegate = Sum;

        Console.WriteLine("Sum method  is not called yet");
        Thread.Sleep(2000);
        Sum(5, 8);
        Console.WriteLine("method call completed");
        #region Lambda
        //// Example using Func delegate
        //Func<int, int, int> add = (x, y) => x + y;
        //int result = add(3, 5);
        //Console.WriteLine($"Result of addition: {result}");

        //// Example using Action delegate
        //Action<string> printMessage = message => Console.WriteLine(message);
        //printMessage("Hello, Action!");
        #endregion

        Console.ReadKey(); // Wait for a key press before exiting
    }

    public static int Sum(int x, int y) {

        Console.WriteLine("Sum method  is  called");
        Thread.Sleep(3000);
        return x + y;
    }



}
