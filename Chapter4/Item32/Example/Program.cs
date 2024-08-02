using System;
using System.Collections.Generic;

class Program
{
    // Main method to run the examples
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Console.WriteLine("Original List:");
        numbers.ForEach(Console.WriteLine);

        Console.WriteLine("\nFiltered List (even numbers):");
        List<int> evenNumbers = Filter(numbers, IsEven);
        evenNumbers.ForEach(Console.WriteLine);

        Console.WriteLine("\nDoubled List:");
        List<int> doubledNumbers = Transform(numbers, Double);
        doubledNumbers.ForEach(Console.WriteLine);

        Console.WriteLine("\nAction Example:");
        ProcessList(numbers, n => Console.WriteLine($"Processing number: {n}"));
    }

    // Method using Predicate to filter list
    static List<T> Filter<T>(List<T> source, Predicate<T> predicate)
    {
        List<T> result = new List<T>();
        foreach (T item in source)
        {
            if (predicate(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    // Method using Function to transform list
    static List<TResult> Transform<T, TResult>(List<T> source, Func<T, TResult> transformer)
    {
        List<TResult> result = new List<TResult>();
        foreach (T item in source)
        {
            result.Add(transformer(item));
        }
        return result;
    }

    // Method using Action to process list
    static void ProcessList<T>(List<T> source, Action<T> action)
    {
        foreach (T item in source)
        {
            action(item);
        }
    }

    // Example Predicate method to check if a number is even
    static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    // Example Function method to double a number
    static int Double(int number)
    {
        return number * 2;
    }
}
