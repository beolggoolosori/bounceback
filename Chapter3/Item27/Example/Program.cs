using System;

// 간단한 인터페이스 정의
public interface IAnimal
{
    void Speak();
}

// 인터페이스를 구현한 클래스
public class Dog : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Woof!");
    }
}

// 확장 메서드를 정의한 클래스
public static class AnimalExtensions
{
    public static void Eat(this IAnimal animal)
    {
        Console.WriteLine("The animal is eating.");
    }

    public static void Sleep(this IAnimal animal)
    {
        Console.WriteLine("The animal is sleeping.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IAnimal myDog = new Dog();
        myDog.Speak();  // 출력: Woof!

        // 확장 메서드 사용
        myDog.Eat();    // 출력: The animal is eating.
        myDog.Sleep();  // 출력: The animal is sleeping.
    }
}
