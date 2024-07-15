using System;

public class Program
{
    // 제네릭 메서드 정의, T는 IComparable 인터페이스를 구현해야 함
    public static T GetMax<T>(T a, T b) where T : IComparable
    {
        return a.CompareTo(b) > 0 ? a : b;
    }

    public static void Main()
    {
        // int는 IComparable 인터페이스를 구현함
        int maxInt = GetMax(5, 10);
        Console.WriteLine($"Max Int: {maxInt}");

        // string 또한 IComparable 인터페이스를 구현함
        string maxString = GetMax("apple", "banana");
        Console.WriteLine($"Max String: {maxString}");
    }
}
