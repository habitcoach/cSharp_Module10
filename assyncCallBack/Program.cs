using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsynchronousDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting the asynchronous demonstration...");

           // Action<string> callback = PrintCallback;

            await ShowWebSite("https://jsonplaceholder.typicode.com/posts/1", PrintCallback) ;

           

            Console.WriteLine("Asynchronous demonstration completed.");
        }

        public static async Task ShowWebSite(string uri, Action<string> callback)
        {
            var client = new HttpClient();

            var msg = await client.GetStringAsync(uri);

            callback(msg);
        }

        public static void PrintCallback(string message)
        {
            Console.WriteLine($"Callback received: {message}");
        }
    }
}
