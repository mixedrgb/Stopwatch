using System;

namespace Stopwatch
{
    public class Stopwatch
    {
        private static DateTime _stopTime;
        private static DateTime _startTime;
        private static bool _isStarted;
        private const string ProgramVersion = "v0.01";

        public void Start()
        {
            if (_isStarted)
                throw new InvalidOperationException("nO!");

            _isStarted = true;
            _startTime = DateTime.Now;
        }

        public void Stop()
        {
            if (!_isStarted)
                throw new InvalidOperationException("nO!");

            _isStarted = false;
            _stopTime = DateTime.Now;
        }

        private TimeSpan ShowTime()
        {
            return _stopTime - _startTime;
        }

//        private static void ParseCommands(string? command)
//        {
//            switch (command?.ToLower())
//            {
//                case "start":
//                    Start();
//                    break;
//                case "stop":
//                    Stop();
//                    break;
//                case "show":
//                    ShowTime();
//                    break;
//                case "exit":
//                    Console.WriteLine("Seeya, bro!");
//                    Environment.Exit(0);
//                    break;
//                default:
//                    Console.WriteLine("No command \"{0}\" available.", command);
//                    break;
//            }
//        }

        internal static void Main()
        {
            Console.WriteLine($"Stopwatch {ProgramVersion}");

            var stopwatch = new Stopwatch();

            while (true)
            {
                var randomNumber = new Random();
                stopwatch.Start();
                Thread.Sleep(randomNumber.Next(1, 2000));
                stopwatch.Stop();
                Console.WriteLine("Duration: {0}", stopwatch.ShowTime());
            }
//            Console.WriteLine("When you're ready.");
//            while (true)
//            {
//                Console.Write("> ");
//                var command = Console.ReadLine();
//                ParseCommands(command);
//            }
        }
    }
}