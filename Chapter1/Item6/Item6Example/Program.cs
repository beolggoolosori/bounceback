using System;

class Program
{
    static void Main(string[] args)
    {
        string firstName = "John";
        string lastName = "Doe";

        Console.WriteLine("Variable names: firstName, lastName");
        Console.WriteLine("Property names: FirstName, LastName");
        Console.WriteLine("Method name: GetFullName");

        string firstName = "John";
        string lastName = "Doe";

        Console.WriteLine($"Variable names: {nameof(firstName)}, {nameof(lastName)}");
        Console.WriteLine($"Property names: {nameof(FirstName)}, {nameof(LastName)}");
        Console.WriteLine($"Method name: {nameof(GetFullName)}");
    }

    public string GetFullName()
    {
        return "John Doe";
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
}