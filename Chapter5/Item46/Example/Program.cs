using System;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // 1. 전통적인 using 블록 사용
        Console.WriteLine("Traditional using block:");
        try
        {
            using (StreamReader reader = new StreamReader("example.txt"))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            } // 여기서 자동으로 reader.Dispose()가 호출됨
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // 2. C# 8.0 이후의 using 선언 사용
        Console.WriteLine("\nC# 8.0 using declaration:");
        try
        {
            using var reader = new StreamReader("example.txt");
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
        } // 이 스코프를 벗어날 때 자동으로 Dispose() 호출
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // 3. using 문을 사용하지 않은 경우 (명시적 Dispose 호출)
        Console.WriteLine("\nManual Dispose without using:");
        StreamReader readerManual = null;
        try
        {
            readerManual = new StreamReader("example.txt");
            string content = readerManual.ReadToEnd();
            Console.WriteLine(content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            if (readerManual != null)
            {
                readerManual.Dispose(); // 리소스를 명시적으로 해제해야 함
            }
        }

        // 4. 예외 처리와 예외 상황 검사
        Console.WriteLine("\nException Handling and Pre-check:");
        try
        {
            int denominator = 0;

            // 예외 상황을 사전에 검사
            if (!IsValidDenominator(denominator))
            {
                Console.WriteLine("Invalid denominator. Division by zero is not allowed.");
                return;
            }

            int result = Divide(10, denominator);
            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        // 5. 잘못된 예외 처리 예제
        Console.WriteLine("\nBad Example: Handling Exception by throwing");
        try
        {
            int result = Divide(10, 0);
            Console.WriteLine($"Result: {result}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // 예외 상황을 검사하는 메서드
    public static bool IsValidDenominator(int denominator)
    {
        return denominator != 0;
    }

    // 예외를 통해 오류를 알리는 메서드
    public static int Divide(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new DivideByZeroException("Denominator cannot be zero.");
        }
        return numerator / denominator;
    }
}
