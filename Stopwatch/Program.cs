namespace Stopwatch
{
    public class Stopwatch
    {
        private static DateTime _stopTime;
        private static DateTime _startTime;
        private static bool _isStarted;
        private const string ProgramVersion = "v0.05";

        private void Start()
        {
            if (_isStarted)
                throw new InvalidOperationException("nO!");

            _isStarted = true;
            _startTime = DateTime.Now;
        }

        private void Stop()
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

        private void ParseCommands(Stopwatch stopwatch, string? command)
        {
            switch (command?.ToLower())
            {
                case "start":
                    Console.WriteLine("Starting!");
                    stopwatch.Start();
                    break;

                case "stop":
                    Console.WriteLine("Stopping!");
                    stopwatch.Stop();
                    break;

                case "show":
                    Console.WriteLine("Time: " + stopwatch.ShowTime());
                    break;

                case "exit":
                    Console.WriteLine("Seeya, bro!");
                    Environment.Exit(0);
                    break;

                case "help":
                    Help();
                    break;

                default:
                    Console.WriteLine("No command \"{0}\" available.", command);
                    break;
            }
        }

        private static void Help()
        {
            Console.WriteLine($"Stopwatch {ProgramVersion}");
            Console.WriteLine("Commands:\n" +
                              "  -i     Interactive input\n" +
                              "\n" +
                              "If no input is specified, the stopwatch is automatic\n" +
                              "until the program is stopped by the user.\n");
        }

        internal static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0].ToLower())
                {
                    case "-h":
                        Help();
                        break;

                    case "-i":
                        Interactive();
                        break;

                    default:
                        Help();
                        Environment.Exit(0);
                        break;
                }
            }
            Automatic();
        }

        private static void Automatic()
        {
            var stopwatch = new Stopwatch();

            while (true)
            {
                var randomNumber = new Random();
                stopwatch.Start();
                Thread.Sleep(randomNumber.Next(1, 2000));
                stopwatch.Stop();
                Console.WriteLine("Duration: {0}", stopwatch.ShowTime());
            }
        }

        private static void Interactive()
        {
            var stopwatch = new Stopwatch();

            while (true)
            {
                Console.Write("> ");
                var command = Console.ReadLine();
                stopwatch.ParseCommands(stopwatch, command);
            }
        }
    }
}