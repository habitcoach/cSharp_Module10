using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        //start()

        var task1 = new Task(() =>
        {
            Console.WriteLine("Task 1  about to run");
        });



        task1.Start();
        task1.Wait();

      

       

        Console.WriteLine("Task 1 finished");
        //task factory
        // Its easy way of starting the task.  Here the task and start are in one single line

        var task02 = Task.Factory.StartNew(() => Console.WriteLine("Task 02 running"));
        task02.Wait();
       

        
        Console.WriteLine("Task 2 finished");
        //task Run
        //Same as Task.Factory but its more concise

        var task03 = Task.Run(() => Console.WriteLine("Task 03 running"));

        task03.Wait();
        Console.WriteLine("Task 3 finished");
        //multiple thread
        //for main thread to wait for multiple thread to finish we can use task.waitAll(array of  task)

        Task[] tasks = new Task[3]

        {

               Task.Factory.StartNew(() => Console.WriteLine("Task1 of tasks running")),
               Task.Factory.StartNew(() => Console.WriteLine("Task2 of tasks running")),
               Task.Factory.StartNew(() =>  SomeLongRunningTask())

        };

        Task.WaitAll(tasks);

        Console.WriteLine("All task finished");

        //Use either factory or run to run multiple task
        //Task[] tasks02 = new Task[3]

        //{

        //     Task.Run( () => Console.WriteLine("Task code finishing 1")),

        //     Task.Run( () => Console.WriteLine("Task code finishing 2")),

        //     Task.Run( () => SomeLongRunningTask())

        //};
     


        //returning from task

        var task04 = Task.Run<string>(() => SomeLongRunningTask());
        task04.Wait();
        Console.WriteLine(task04.Result);
        Console.WriteLine("Task 4 finished");
    }

    public static string SomeLongRunningTask() {
        Thread.Sleep(4000);
        //Some long running task
        Console.WriteLine("Some long running task finished");
        return "value returned from task";
    
    }
}
