using System;
using System.Collections.Generic;

class GenericExample<T>
{
    private T data;

    public GenericExample(T value)
    {
        data = value;
    }

    public void DisplayData()
    {
        Console.WriteLine($"Data: {data}");
    }
}

class NonGenericExample
{
    private object data;

    public NonGenericExample(object value)
    {
        data = value;
    }

    public void DisplayData()
    {
        Console.WriteLine($"Data: {data}");
    }
}

class Program
{
    static void Main()
    {
        // 제네릭을 사용하는 예
        GenericExample<int> intGeneric = new GenericExample<int>(123);
        intGeneric.DisplayData();  // 출력: Data: 123

        GenericExample<string> stringGeneric = new GenericExample<string>("Hello Generic");
        stringGeneric.DisplayData();  // 출력: Data: Hello Generic

        // 제네릭을 사용하지 않는 예
        NonGenericExample intNonGeneric = new NonGenericExample(456);
        intNonGeneric.DisplayData();  // 출력: Data: 456

        NonGenericExample stringNonGeneric = new NonGenericExample("Hello Non-Generic");
        stringNonGeneric.DisplayData();  // 출력: Data: Hello Non-Generic
    }
}
