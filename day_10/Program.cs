using System;
using System.Threading.Tasks;


#region Notes
/*
 First run the task01 alone.  When you do that it will execute but does not produce any result as complier did not wait.  Now add the task1.wait() to get the result
 */
#endregion

class Program
{
    static void Main()
    {
        Task task1 = new Task(new Action(GetTheTime));
        Console.WriteLine("Task 01 started");
        task1.Start();

        Console.WriteLine("some other taskes after Task01 is called");

        Console.WriteLine("waiting for task 1 to complete");

        #region Notes

        /*
         if you are not running the GetTheTime as taks then the controller will wait for 4 sec before it
        goes to next line that is console.writeline().  Hence when we use task and start the task the 
        task will run in the seperate thread and main thread will continue execution.  Now if you do not make
        the main thread to wait before the GetTheTIme is execured then the program will end.  Hence make
        sure to wait for the execution use wait() method.  You can check this wait breakpoint.  remove the 
        task and call the method normally.  It will take 4 sec before it goes to next line.
         */

        #endregion

        task1.Wait(); // Put it in the end to see task 2 and task 3 start which will execute even before task 1.


        //Console.WriteLine("Line of code after wait");

       // Anonymous method

        Task task02 = new Task(delegate
        {

            Console.WriteLine("Task02: The time now is {0}", DateTime.Now);

        });

        ////lambda 
        
        Task task03 = new Task(() =>
        {

            Console.WriteLine("Task 03: The time now is {0}", DateTime.Now);

        });

        task02.Start();
        task03.Start();

        //Console.WriteLine("Press any key to exit...");
        //Console.ReadKey();
    }

    static void GetTheTime()
    {Thread.Sleep(4000);
        Console.WriteLine("The time now is {0}", DateTime.Now);
    }
}
