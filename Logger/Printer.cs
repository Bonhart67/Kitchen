using System.Diagnostics;

namespace Kitchen.Logger
{
    public class Printer
    {
        private static Stopwatch _stopWatch = new Stopwatch();
        public Printer() => _stopWatch.Start();
        public static void Print(string str)
        {
            System.Console.WriteLine($"[{ _stopWatch.Elapsed }] { str }");
        }
    }
}