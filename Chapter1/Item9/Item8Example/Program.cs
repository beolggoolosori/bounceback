using System;

class Program
{
    public static event EventHandler MultipleEvent;

    public static void Main()
    {
        int firstNumber = 3;
        int secondNumber = 4;
        int thirdNumber = 5;

        Console.WriteLine($"A few numbers:{firstNumber}, {secondNumber}, {thirdNumber}");
        Console.WriteLine($"A few numbers:{firstNumber.ToString()},{secondNumber.ToString()}, {thirdNumber.ToString()}");
    }
}
