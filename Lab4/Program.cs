using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DontTouchMe;

namespace Lab4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //TASK: First, implement the commented out code below.

            var timer = new Stopwatch();

            Console.WriteLine("Hello Lab 4!");

            Console.WriteLine(
                $"I'm going to run a set of fake tasks that update a single counter that is not type safe...whats going to happen?");

            var someCounter = 0;
            var listOfTasks = new List<Task>();
            var tasksToRun = 1000;
            var threadlock = new object();
            timer.Restart();
            for (int i = 0; i < tasksToRun; i++)
            {
                listOfTasks.Add(Task.Run(() =>
                {
                    Console.Write(".");
                    Console.Write(".");
                    Console.Write(".");
                    Console.Write(".");

                    lock (threadlock)
                    {
                        someCounter++;
                    }
                }));
            }

            await Task.WhenAll(listOfTasks);

            Console.WriteLine($"We ran {tasksToRun} tasks and ended up with a counter value of {someCounter}.");

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
