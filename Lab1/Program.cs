using System;
using System.Diagnostics;
using System.Threading.Tasks;
using DontTouchMe;

namespace Lab1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //TASK: Discussion! Which of the below will be faster? Why?

            var slowProcessor = new SlowProcessor();
            var timer = new Stopwatch();

            Console.WriteLine("Hello Lab 1!");

            var countingTarget = 5;

            Console.WriteLine($"I'm going to count to {countingTarget} now, using a SYNCHRONOUS method. Lets see how long that takes...");

            timer.Start();
            var syncCountToANumberSlowly = slowProcessor.CountToANumberSlowly(countingTarget);
            WriteResultsToConsole(timer, syncCountToANumberSlowly);

            Console.WriteLine($"Now I'm going to count to {countingTarget}, this time using an ASYNC method. Lets see how long that takes...");

            timer.Restart();
            var asyncCountToANumberSlowly = await slowProcessor.CountToANumberSlowlyAsync(countingTarget);
            WriteResultsToConsole(timer, asyncCountToANumberSlowly);

            Console.WriteLine("Press the ANY key to close.");
            Console.ReadKey();
        }

        private static void WriteResultsToConsole(Stopwatch timer, string message)
        {
            Console.WriteLine(message);
            Console.WriteLine($"That took me {timer.Elapsed.TotalMilliseconds} seconds.\n");
        }
    }
}
