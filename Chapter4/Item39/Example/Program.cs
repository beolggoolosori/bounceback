using System;

public class Program
{
    public static void Main()
    {
        Func<int, int> divideByNumber = x => 10 / x;

        try
        {
            int result = divideByNumber(0); // 0으로 나누기 때문에 예외 발생
            Console.WriteLine(result);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");
        }
    }
}

using System;

public class Program
{
    public static void Main()
    {
        Func<int, int?> divideByNumber = x =>
        {
            if (x == 0)
            {
                Console.WriteLine("Cannot divide by zero.");
                return null; // 예외 대신 null을 반환하여 안전하게 처리
            }
            return 10 / x;
        };

        int? result = divideByNumber(0);
        if (result.HasValue)
        {
            Console.WriteLine(result.Value);
        }
    }
}


using System;

public class Program
{
    public static void Main()
    {
        Action<int> printDivisionResult = x =>
        {
            if (x == 0)
            {
                Console.WriteLine("Cannot divide by zero.");
            }
            else
            {
                Console.WriteLine(10 / x);
            }
        };

        printDivisionResult(0); // 0으로 나누는 경우를 안전하게 처리
    }
}
