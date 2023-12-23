using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsynchronousDemo
{
    class Program
    {
       public static   void Main(string[] args)
        {
            Console.WriteLine("Starting the asynchronous demonstration...");

            // Call an asynchronous method
              DoAsyncWork();

          

            for (int i = 0; i < 10; i++) {

                Console.WriteLine("some other work");
                Thread.Sleep(500);
            }

            Console.WriteLine("Asynchronous demonstration completed.");
        }

        //public static void DoAsyncWork()
        //{
        //    Thread.Sleep(5000);
        //    Console.WriteLine("do asyn method");
        //}



        static async Task DoAsyncWork()
        {
            Console.WriteLine("Async work started.");

            using (HttpClient client = new HttpClient())
            {

                // Simulate an async operation, such as making an HTTP request
                string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/1");
                Thread.Sleep(2000);
                Console.WriteLine($"Received response: {response}");

            }

            Console.WriteLine("Async work completed.");
        }
    }
}
