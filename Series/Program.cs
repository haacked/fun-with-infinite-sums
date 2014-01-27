using System;
using System.Linq;
using MathSeries;

class Program
{
    static void Main(string[] args)
    {
        foreach (var partialSum in PartialSums.Euler(1000000).Select(term => term.Value))
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(partialSum);
        }
        Console.ReadLine();
    }
}
