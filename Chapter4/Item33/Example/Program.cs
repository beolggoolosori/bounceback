using System;
using System.Collections.Generic;

public static class FibonacciSequence
{
    public static IEnumerable<long> Generate(int count)
    {
        long previous = 0, next = 1;
        for (int i = 0; i < count; i++)
        {
            yield return previous;
            long temp = next;
            next = previous + next;
            previous = temp;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        foreach (var number in FibonacciSequence.Generate(10))
        {
            Console.WriteLine(number);
        }
    }
}