using System;
using System.Threading.Tasks;

namespace DontTouchMe
{
    public class SlowProcessor
    {
        public string CountToANumberSlowly(int targetNumber)
        {
            return CountToANumberSlowlyAsync(targetNumber).Result;
        }

        public async Task<string> CountToANumberSlowlyAsync(int targetNumber)
        {
            if(targetNumber>10)
                throw new Exception("Dont be silly, we only have an hour.");

            if (targetNumber < 0)
                throw new Exception("Well, that wasnt clever, was it?");

            var count = 0;
            while (count < targetNumber)
            {
                count++;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            return $"I counted all the way to {count}!";
        }
    }
}
