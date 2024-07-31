using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Enumerable.Range(1, 1000000000).ToList(); // 큰 데이터셋 생성

        // LINQ 쿼리 구문 실행 시간 측정
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        var evenNumbersUsingLinq = numbers.Where(n => n % 2 == 0).ToList();
        stopwatch.Stop();
        long linqElapsedTime = stopwatch.ElapsedMilliseconds;

        Console.WriteLine("LINQ Execution Time: " + linqElapsedTime + " ms");

        // 루프를 사용한 실행 시간 측정
        stopwatch.Reset();

        stopwatch.Start();
        List<int> evenNumbersUsingLoops = new List<int>();
        foreach (var number in numbers)
        {
            if (number % 2 == 0)
            {
                evenNumbersUsingLoops.Add(number);
            }
        }
        stopwatch.Stop();
        long loopsElapsedTime = stopwatch.ElapsedMilliseconds;

        Console.WriteLine("Loops Execution Time: " + loopsElapsedTime + " ms");

        // 결과 비교
        Console.WriteLine("Number of even numbers using LINQ: " + evenNumbersUsingLinq.Count);
        Console.WriteLine("Number of even numbers using loops: " + evenNumbersUsingLoops.Count);
    }
}
