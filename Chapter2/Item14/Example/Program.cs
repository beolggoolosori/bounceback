using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Creating an instance of MyClass.");
        MyClass instance = new MyClass(5);
        Console.WriteLine($"Value of _number: {instance.Number}");
    }
}

public class BaseClass
{
    public BaseClass()
    {
        Console.WriteLine("BaseClass constructor called.");
    }
}

public class MyClass : BaseClass
{
    // 정적 필드 초기화
    private static int _staticNumber = InitializeStaticNumber();

    // 인스턴스 필드 초기화
    private int _number = 10;

    // 정적 생성자
    static MyClass()
    {
        Console.WriteLine("Static constructor called.");
        _staticNumber += 1;
    }

    // 기본 생성자
    public MyClass() : this(42) // 생성자 체이닝
    {
        Console.WriteLine("MyClass default constructor called.");
    }

    // 매개변수 있는 생성자
    public MyClass(int number)
    {
        Console.WriteLine("MyClass constructor with parameter called.");
        _number = number;
    }

    // 정적 필드 초기화 메서드
    private static int InitializeStaticNumber()
    {
        Console.WriteLine("Static field initializer called.");
        return 30;
    }

    public int Number
    {
        get { return _number; }
    }
}
