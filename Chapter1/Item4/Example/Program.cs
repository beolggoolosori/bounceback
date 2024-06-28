using System;

class Program
{
    static void Main(string[] args)
    {
        string name = "John";
        int age = 30;
        string city = "New York";

        // string.Format() 방식
        string message = string.Format("My name is {0}, I am {1} years old and I live in {2}.", name, age, city);
        Console.WriteLine(message);

         // 문자열 보간 방식
        string message = $"My name is {name}, I am {age} years old and I live in {city}.";
        Console.WriteLine(message);
    }
}