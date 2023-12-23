using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    private static readonly object mylock = new object();

    #region Notes
    /*
     When a thread encounters the lock (mylock) statement, it attempts to acquire the lock on the specified object (mylock in this case). If no other thread currently holds the lock, the requesting thread acquires the lock and continues executing the code within the lock statement.
If another thread already holds the lock, the requesting thread is blocked, or "waits" until the lock is released by the thread currently holding it.
The lock statement ensures that only one thread can hold the lock at any given time. This exclusivity prevents multiple threads from concurrently executing the critical section of code protected by the lock.
The lock is automatically released when the thread exits the lock block, either by reaching the end of the block or by encountering an exception. This ensures that the lock is not held indefinitely, allowing other threads to acquire it.
     */
    #endregion
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
        lock (mylock)  // synchronize access to a shared resource
        {
           
            Console.WriteLine($"Thread {threadId} has acquired the resource.");
            Thread.Sleep(3000); // Simulate some work
            Console.WriteLine($"Thread {threadId} has released the resource.");
        }
    }
}
