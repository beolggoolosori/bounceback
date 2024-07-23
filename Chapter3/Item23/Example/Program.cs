using System;

public static class Example
{
    public static T Add<T>(T left, T right, Func<T, T, T> AddFunc)
    {
        return AddFunc(left, right);
    }
}

public class MyClass2
{
    public int value;

    public MyClass2(int value)
    {
        this.value = value;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        MyClass2 a = new MyClass2(1);
        MyClass2 b = new MyClass2(2);
        MyClass2 result = Example.Add(a, b, (left, right) => new MyClass2(left.value + right.value));
        Console.WriteLine(result.value); // Output: 3
    }
}
