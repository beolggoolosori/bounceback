using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // LINQ 쿼리 구문을 사용한 예제
        var evenNumbersUsingLinq = numbers.Where(n => n % 2 == 0);

        Console.WriteLine("Even Numbers (using LINQ):");
        foreach (var number in evenNumbersUsingLinq)
        {
            Console.WriteLine(number);
        }

        // LINQ를 사용한 정렬 예제
        var sortedNumbersUsingLinq = numbers.OrderBy(n => n);

        Console.WriteLine("Sorted Numbers (using LINQ):");
        foreach (var number in sortedNumbersUsingLinq)
        {
            Console.WriteLine(number);
        }

        // 루프를 사용한 예제
        List<int> evenNumbersUsingLoops = new List<int>();
        foreach (var number in numbers)
        {
            if (number % 2 == 0)
            {
                evenNumbersUsingLoops.Add(number);
            }
        }

        Console.WriteLine("Even Numbers (using loops):");
        foreach (var number in evenNumbersUsingLoops)
        {
            Console.WriteLine(number);
        }

        // 루프를 사용한 정렬 예제
        List<int> sortedNumbersUsingLoops = new List<int>(numbers);
        sortedNumbersUsingLoops.Sort();

        Console.WriteLine("Sorted Numbers (using loops):");
        foreach (var number in sortedNumbersUsingLoops)
        {
            Console.WriteLine(number);
        }
    }
}
