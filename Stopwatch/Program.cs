using System;

namespace Stopwatch
{
    public class Stopwatch
    {
        private static DateTime _startTime;
        private static TimeSpan _stopTime;
        private const string _programVersion = "v0.01";

        private static void Start()
        {
            _startTime = DateTime.Now;
        }

        private static void Stop()
        {
            _stopTime = DateTime.Now - _startTime;
        }

        internal static void Main()
        {
            Console.WriteLine($"Stopwatch {_programVersion}");
            Start();
            Thread.Sleep(new Random().Next(0,2000));
            Stop();
            Console.WriteLine("Total lapsed time: {0}", _stopTime);
        }
    }
}