using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // 첫 번째 예제: 바인딩된 변수 수정으로 인한 문제
        Console.WriteLine("Example 1: Issue with modifying bound variables");

        List<Action> actionsWithIssue = new List<Action>();

        for (int i = 0; i < 3; i++)
        {
            // i를 캡처하는 람다 표현식
            actionsWithIssue.Add(() => Console.WriteLine($"Value of i in closure: {i}"));
        }

        // actions 리스트의 모든 람다 실행
        Console.WriteLine("Executing actions with issue:");
        foreach (var action in actionsWithIssue)
        {
            action(); // 이 시점에 i의 값은 3으로 고정됨
        }

        // 두 번째 예제: 바인딩된 변수 수정 방지
        Console.WriteLine("\nExample 2: Avoiding issue by copying bound variables");

        List<Action> actionsWithoutIssue = new List<Action>();

        for (int i = 0; i < 3; i++)
        {
            int capturedValue = i; // i의 복사본을 생성하여 캡처
            actionsWithoutIssue.Add(() => Console.WriteLine($"Value of capturedValue in closure: {capturedValue}"));
        }

        // actions 리스트의 모든 람다 실행
        Console.WriteLine("Executing actions without issue:");
        foreach (var action in actionsWithoutIssue)
        {
            action(); // 각 람다 표현식이 고유한 값을 출력
        }
    }
}
