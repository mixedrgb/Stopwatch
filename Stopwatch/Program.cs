using System;

namespace Stopwatch
{
    public class Stopwatch
    {
        private static DateTime _stopTime;
        private static DateTime _startTime;
        private static bool _isStarted;
        private const string ProgramVersion = "v0.01";

        private static void Start()
        {
            if (!_isStarted)
            {
                _isStarted = true;
                _startTime = DateTime.Now;
                Console.WriteLine("Stopwatch started at {0}", _startTime);
            }
            else
            {
                //Console.WriteLine("Already started!");
                var e = new InvalidOperationException();
                Console.WriteLine("Already started!\nError: {0}", e.Message);
            }
        }

        private static void Stop()
        {
            if (_isStarted)
            {
                _isStarted = false;
                _stopTime = DateTime.Now;
                Console.WriteLine("Stopwatch stopped at {0}", _stopTime);
            }
            else
            {
                Console.WriteLine("Already stopped!");
            }
        }

        private static void ShowTime()
        {
            if (_isStarted)
            {
                Console.WriteLine("Can't show time until stopped.");
            }
            else
            {
                Console.WriteLine("Total time lapsed was {0}", _stopTime - _startTime);
            }
        }

        private static void ParseCommands(string? command)
        {
            switch (command?.ToLower())
            {
                case "start":
                    Start();
                    break;
                case "stop":
                    Stop();
                    break;
                case "show":
                    ShowTime();
                    break;
                case "exit":
                    Console.WriteLine("Seeya, bro!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("No command \"{0}\" available.", command);
                    break;
            }
        }

        internal static void Main()
        {
            Console.WriteLine($"Stopwatch {ProgramVersion}");
            Console.WriteLine("When you're ready.");
            while (true)
            {
                Console.Write("> ");
                var command = Console.ReadLine();
                ParseCommands(command);
            }
        }
    }
}