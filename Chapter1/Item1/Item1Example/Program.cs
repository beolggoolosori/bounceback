using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // var를 사용하여 초기화되는 변수
        var data = GetData();
        Console.WriteLine("데이터 타입: " + data.GetType().Name);
        
        // 작업을 수행하는 과정에서 변수의 실제 타입을 명확히 인지하지 못하는 경우
        if (data is List<int>)
        {
            Console.WriteLine("List<int> 타입으로 처리");
            // List<int>로 예상되는 로직 처리
            foreach (var num in (List<int>)data)
            {
                Console.Write(num + " ");
            }
        }
        else
        {
            Console.WriteLine("예상하지 못한 데이터 타입: " + data.GetType().Name);
        }
        Console.WriteLine();
    }

    // 데이터 반환 타입이 명확하지 않은 메소드
    private static object GetData()
    {
        // 반환 타입이 List<int>인 경우
        return new List<int> { 1, 2, 3, 4, 5 };

        // 반환 타입이 다른 경우를 고려하지 않는다면,
        // return new List<string> { "one", "two", "three" };
    }
}