using System;

namespace TinyProcessProfiler
{
    class Program
    {
        static void Main(string[] args)
        {
            (string process, int iterations) = GetArguments(args);
        }

        private static (string process, int iterations) GetArguments(string[] args)
        {
            var process = string.Empty;
            var iterations = 1;

            if(args.Length > 0)
            {
                process = args[0];
            }
            else
            {
                PrintArgumentErrorMessage();
            }

            if (args.Length > 1 && !int.TryParse(args[1], out iterations))
            {
                PrintArgumentErrorMessage();
                process = string.Empty;
            }

            return (process, iterations);
        }

        private static void PrintArgumentErrorMessage()
        {
            throw new NotImplementedException();
        }
    }
}
