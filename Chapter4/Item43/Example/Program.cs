using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var customers = new List<string> { "Alice", "Bob", "Charlie" };

        // Single() 사용 예제
        Console.WriteLine("Single() Example:");
        try
        {
            // 이름이 "Alice"인 고객이 하나만 있어야 하는 경우
            var customer = customers.Single(c => c == "Alice");
            Console.WriteLine($"Found customer: {customer}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        try
        {
            // 이름이 "David"인 고객이 없는 경우
            var customer = customers.Single(c => c == "David");
            Console.WriteLine($"Found customer: {customer}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); // 예외 발생: 시퀀스에 요소가 없습니다.
        }

        // First() 사용 예제
        Console.WriteLine("\nFirst() Example:");
        try
        {
            // 이름이 "Bob"인 고객이 첫 번째로 나타나는 경우
            var customer = customers.First(c => c == "Bob");
            Console.WriteLine($"Found customer: {customer}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        try
        {
            // 이름이 "David"인 고객이 없는 경우
            var customer = customers.First(c => c == "David");
            Console.WriteLine($"Found customer: {customer}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); // 예외 발생: 시퀀스에 요소가 없습니다.
        }

        // SingleOrDefault()와 FirstOrDefault() 사용 예제
        Console.WriteLine("\nSingleOrDefault() and FirstOrDefault() Example:");

        // SingleOrDefault: 조건을 만족하는 요소가 없으면 null 반환
        var customer1 = customers.SingleOrDefault(c => c == "David");
        Console.WriteLine($"SingleOrDefault found customer: {customer1 ?? "None"}"); // 출력: Found customer: None

        // FirstOrDefault: 조건을 만족하는 첫 번째 요소가 없으면 null 반환
        var customer2 = customers.FirstOrDefault(c => c == "David");
        Console.WriteLine($"FirstOrDefault found customer: {customer2 ?? "None"}"); // 출력: Found customer: None
    }
}
