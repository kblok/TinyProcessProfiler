using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace TinyProcessProfiler
{
    class Program
    {
        static void Main(string[] args)
        {
            (string processPath, int iterations) = GetArguments(args);

            if (!string.IsNullOrEmpty(processPath))
            {
                var iterationData = new List<TimeSpan>();
                var currentIteration = 1;

                while (currentIteration <= iterations)
                {
                    Console.WriteLine($"Running iteration: {currentIteration}");

                    var stopwatch = new Stopwatch();
                    var process = BuildProcess(processPath);

                    stopwatch.Start();
                    process.Start();
                    process.WaitForExit();
                    stopwatch.Stop();

                    iterationData.Add(stopwatch.Elapsed);
                }

                PrintReport(iterationData);
            }
        }

        private static void PrintReport(List<TimeSpan> iterationData)
        {
            Console.WriteLine("FINISHED");
            Console.WriteLine($"Fastest run:\t\t {iterationData.Min().Seconds} seconds");
            Console.WriteLine($"Slowest run:\t\t {iterationData.Max().Seconds} seconds");
            Console.WriteLine($"Avg run:\t\t {iterationData.Select(t => t.Seconds).Average()} seconds");
            Console.WriteLine($"Std deviation:\t\t {StandardDeviation(iterationData.Select(t => t.Seconds))}");
        }


        //https://stackoverflow.com/questions/895929/how-do-i-determine-the-standard-deviation-stddev-of-a-set-of-values
        public static double StandardDeviation(IEnumerable<int> valueList)
        {
            double M = 0.0;
            double S = 0.0;
            int k = 1;
            foreach (var value in valueList)
            {
                double tmpM = M;
                M += (value - tmpM) / k;
                S += (value - tmpM) * (value - M);
                k++;
            }
            return Math.Sqrt(S / (k - 2));
        }

        private static Process BuildProcess(string processPath)
        {
            var process = new Process();
            process.StartInfo.FileName = processPath;

            return process;
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
            Console.WriteLine("Usage: \n tinyprocessprofiler.exe <process to execute> <number of iterations>");
        }
    }
}
