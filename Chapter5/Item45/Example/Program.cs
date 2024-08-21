using System;

public class Program
{
    public static void Main()
    {
        try
        {
            int denominator = 0;

            // 사전 검사
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
            // 이 단계에서 예외가 발생하는 경우는 사전에 예상치 못한 상황
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    // 사전 검사 메서드
    public static bool IsValidDenominator(int denominator)
    {
        return denominator != 0;
    }

    // 예외를 통해 오류를 알리는 방식
    public static int Divide(int numerator, int denominator)
    {
        // 이미 사전 검사를 했으므로 이 단계에서는 예외가 발생하지 않을 가능성이 큼
        return numerator / denominator;
    }
}
