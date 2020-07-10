using System;

namespace Kitchen
{
    public class Printer
    {
        public static void Display(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"[{ Timer.StopWatch.Elapsed }] { message }");
            Console.ResetColor();
        }
    }
}