using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

internal class Program
{
    public static void waste_time(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)/*A CancellationToken enables cooperative 
                                            * cancellation between threads,
                                            * thread pool work items, or Task
                                            * objects. You create a cancellation token by instantiating a 
                                            * CancellationTokenSource object,
                                            * which manages cancellation tokens retrieved from its 
                                            * CancellationTokenSource.Token property.*/
                                            
        {
            if (1 == 1)
            {
                int temp = 120;
            }
        }
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter Number of threads to run");
        Console.WriteLine("NOTE DO NOT EXCEED THREAD COUNT CRASHING MAY OCCUR");
        var userInput = Console.ReadLine();
        var numThreads = int.Parse(userInput);
        CancellationTokenSource cts = new();

        var threads = Enumerable.Range(0, numThreads).Select(_ => new Thread(() => waste_time(cts.Token))).ToList();

        threads.ForEach(item => item.Start());

        Console.WriteLine($"Stress Test Started using {numThreads} threads");
        Console.WriteLine("Press Enter To Stop Stress Test");
        Console.ReadLine();

        cts.Cancel();

        threads.ForEach(t => t.Join());

        Console.WriteLine("Stress Test Ended Press Enter to Exit");
        Console.ReadLine();
        //this is a demo
    }


}