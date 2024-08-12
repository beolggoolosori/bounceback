using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };

        // 지연 수행: 쿼리 정의 시점에는 실행되지 않음
        var evenNumbers = numbers.Where(x => x % 2 == 0);

        // 데이터 소스를 변경
        numbers.Add(6);

        // 지연 수행된 쿼리 결과를 출력 (데이터 소스가 변경된 이후의 결과를 반영)
        Console.WriteLine("Deferred Execution:");
        foreach (var number in evenNumbers)
        {
            Console.WriteLine(number); // 출력: 2, 4, 6
        }
    }
}

public class Program
{
    public static void Main()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };

        // 즉시 수행: ToList()를 사용하여 쿼리를 즉시 실행
        var evenNumbers = numbers.Where(x => x % 2 == 0).ToList();

        // 데이터 소스를 변경
        numbers.Add(6);

        // 즉시 수행된 결과를 출력 (변경 이전의 결과를 고정)
        Console.WriteLine("Immediate Execution:");
        foreach (var number in evenNumbers)
        {
            Console.WriteLine(number); // 출력: 2, 4
        }
    }
}

