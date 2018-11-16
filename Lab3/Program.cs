using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DontTouchMe;

namespace Lab2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //TASK: First, implement the commented out code below.

            var slowProcessor = new SlowProcessor();
            var timer = new Stopwatch();

            Console.WriteLine("Hello Lab 3!");

            var countingTarget1 = 2;
            var countingTarget2 = 7;
            var countingTarget3 = 3;

            Console.WriteLine(
                $"I'm going to count to {countingTarget1}, then I'm going to count to  {countingTarget2}, and then I'm going to going to count to {countingTarget3} using a SYNCHRONOUS method. Lets see how long that takes...");

            timer.Start();
            var syncCountToANumberSlowly1 = slowProcessor.CountToANumberSlowly(countingTarget1);
            var syncCountToANumberSlowly2 = slowProcessor.CountToANumberSlowly(countingTarget2);
            var syncCountToANumberSlowly3 = slowProcessor.CountToANumberSlowly(countingTarget3);

            WriteResultsToConsole(timer,
                new[] { syncCountToANumberSlowly1, syncCountToANumberSlowly2, syncCountToANumberSlowly3 });

            Console.WriteLine($"Now I'm going to do that again, this time using an ASYNC method. Lets see how long that takes...");

            timer.Restart();
            var aggregatedTaskResult = await Task.WhenAll(
                slowProcessor.CountToANumberSlowlyAsync(countingTarget1),
                slowProcessor.CountToANumberSlowlyAsync(countingTarget2),
                slowProcessor.CountToANumberSlowlyAsync(countingTarget3));

            var asyncCountToANumberSlowly1 = aggregatedTaskResult.GetValue(0).ToString();
            var asyncCountToANumberSlowly2 = aggregatedTaskResult.GetValue(1).ToString();
            var asyncCountToANumberSlowly3 = aggregatedTaskResult.GetValue(2).ToString();

            WriteResultsToConsole(timer,
                new[] { asyncCountToANumberSlowly1, asyncCountToANumberSlowly2, asyncCountToANumberSlowly3 });

            if(timer.Elapsed.TotalSeconds > 8)
                Console.WriteLine("This could be done faster...");
            else
                Console.WriteLine("Yay I'm fast now!");

            Console.WriteLine("Press the ANY key to close.");
            Console.ReadKey();
        }

        private static void WriteResultsToConsole(Stopwatch timer, string[] messages)
        {
            foreach (var message in messages)
                Console.WriteLine(message);

            Console.WriteLine($"That took me {timer.Elapsed.TotalMilliseconds} seconds.\n");
        }
    }
}
