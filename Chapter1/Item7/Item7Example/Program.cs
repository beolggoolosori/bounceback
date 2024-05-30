using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Predicate<T> 예제
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
        Predicate<int> isEven = IsEven;
        List<int> evenNumbers = numbers.FindAll(isEven);
        Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));

        // Func<T, TResult> 예제
        Func<int, int, int> add = Add;
        int sum = add(5, 10);
        Console.WriteLine($"Sum: {sum}");

        // Action<T> 예제
        Action<string> printMessage = PrintMessage;
        printMessage("Hello, World!");

        // Func<T, bool> 예제 (Predicate<T>와 동일)
        Func<int, bool> isOdd = IsOdd;
        List<int> oddNumbers = numbers.FindAll(new Predicate<int>(isOdd));
        Console.WriteLine("Odd numbers: " + string.Join(", ", oddNumbers));
    }

    // Predicate<T> 메서드
    static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    // Func<T, TResult> 메서드
    static int Add(int a, int b)
    {
        return a + b;
    }

    // Action<T> 메서드
    static void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    // Func<T, bool> 메서드 (Predicate<T>와 동일)
    static bool IsOdd(int number)
    {
        return number % 2 != 0;
    }
}