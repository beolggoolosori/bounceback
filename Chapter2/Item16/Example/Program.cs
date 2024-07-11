using System;

public class BaseClass
{
    public BaseClass()
    {
        Init();
    }

    public virtual void Init()
    {
        Console.WriteLine("Base Init");
    }
}

public class DerivedClass : BaseClass
{
    private int _number = 5;

    public DerivedClass()
    {
    }

    public override void Init()
    {
        Console.WriteLine($"Derived Init: {_number}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        BaseClass obj = new DerivedClass();
    }
}
