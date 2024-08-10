using System;
using System.Collections.Generic;

public class Program
{
    // 숫자가 짝수인지 확인하는 메서드
    public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    public static void Main()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

        // 메서드를 사용하여 필터링
        var evenNumbers = numbers.FindAll(IsEven);

        Console.WriteLine("Even Numbers (Using Method):");
        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }
}

public class Program
{
    public static void Main()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

        // 람다 표현식을 사용하여 필터링
        var evenNumbers = numbers.FindAll(num => num % 2 == 0);

        Console.WriteLine("Even Numbers (Using Lambda Expression):");
        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }
}
