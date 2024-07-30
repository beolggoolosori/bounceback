using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 컬렉션을 반환하는 메서드 테스트
        List<int> primesList = GetPrimesList(10, 5);
        Console.WriteLine("Primes (List):");
        foreach (int prime in primesList)
        {
            Console.WriteLine(prime);
        }

        // 이터레이터를 반환하는 메서드 테스트
        IEnumerable<int> primesIterator = GetPrimesIterator(10, 5);
        Console.WriteLine("Primes (Iterator):");
        foreach (int prime in primesIterator)
        {
            Console.WriteLine(prime);
        }
    }

    // 컬렉션을 반환하는 메서드
    public static List<int> GetPrimesList(int start, int count)
    {
        List<int> primes = new List<int>();
        int number = start;
        while (primes.Count < count)
        {
            if (IsPrime(number))
            {
                primes.Add(number);
            }
            number++;
        }
        return primes;
    }

    // 이터레이터를 반환하는 메서드
    public static IEnumerable<int> GetPrimesIterator(int start, int count)
    {
        int found = 0;
        int number = start;
        while (found < count)
        {
            if (IsPrime(number))
            {
                found++;
                yield return number;
            }
            number++;
        }
    }

    // 소수 판별 메서드
    private static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}
