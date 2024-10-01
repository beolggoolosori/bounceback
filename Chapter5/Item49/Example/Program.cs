using System;

public class Calculator
{
    public int Divide(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new DivideByZeroException("분모는 0이 될 수 없습니다.");

        return numerator / denominator;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();

        try
        {
            int result = calculator.Divide(10, 0);
            Console.WriteLine($"결과: {result}");
        }
        // 예외 필터를 사용하여 DivideByZeroException만 필터링
        catch (DivideByZeroException ex) when (LogException(ex))
        {
            // 필터 조건이 true인 경우 이 블록이 실행됨
            Console.WriteLine("0으로 나눌 수 없습니다.");
        }
    }

    // 예외를 로그하고 필터 조건으로 사용 (항상 true를 반환하여 필터링)
    static bool LogException(Exception ex)
    {
        Console.WriteLine($"예외 발생: {ex.Message}");
        return true;  // 필터링 조건에 true를 반환
    }
}
