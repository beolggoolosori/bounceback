public class BaseClass
{
    public void Display()
    {
        Console.WriteLine("BaseClass Display");
    }
}

public class DerivedClass : BaseClass
{
    public new void Display()
    {
        Console.WriteLine("DerivedClass Display");
    }
}

public class Program
{
    static void Main()
    {
        BaseClass objBase = new BaseClass();
        DerivedClass objDerived = new DerivedClass();
        BaseClass objDerivedAsBase = new DerivedClass();

        objBase.Display();
        objDerived.Display();
        objDerivedAsBase.Display();
    }
}
