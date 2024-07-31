using System;
using System.Collections.Generic;

public static class SequenceExtensions
{
    // 중복 값을 제거하는 컨티뉴어블 메서드
    public static IEnumerable<int> Unique(IEnumerable<int> nums)
    {
        var uniqueVals = new HashSet<int>();
        foreach (var num in nums)
        {
            if (uniqueVals.Add(num))
            {
                yield return num;
            }
        }
    }

    // 제곱 값을 계산하는 컨티뉴어블 메서드
    public static IEnumerable<int> Square(IEnumerable<int> nums)
    {
        foreach (var num in nums)
        {
            yield return num * num;
        }
    }
}

public class Program
{
    public static void Main()
    {
        var numbers = new List<int> { 1, 2, 2, 3, 4, 4, 5 };

        // 컨티뉴어블 메서드를 사용하여 중복을 제거하고 제곱 값을 계산
        var result = numbers
            .Unique()
            .Square();

        foreach (var num in result)
        {
            Console.WriteLine(num); // 출력: 1, 4, 9, 16, 25
        }
    }
}
