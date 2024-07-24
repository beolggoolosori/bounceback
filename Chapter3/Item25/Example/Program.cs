using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        // DataConverter 테스트
        DataConverter converter = new DataConverter();

        string jsonData = "{\"Name\":\"John\", \"Age\":30}";
        var person = converter.ConvertData<Person>(jsonData);
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

        string jsonListData = "[{\"Name\":\"Alice\", \"Age\":25}, {\"Name\":\"Bob\", \"Age\":28}]";
        var people = converter.ConvertData<List<Person>>(jsonListData);
        foreach (var p in people)
        {
            Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
        }

        // FindMax 테스트
        int maxInt = FindMax(10, 20);
        Console.WriteLine($"Max Int: {maxInt}");

        string maxString = FindMax("apple", "banana");
        Console.WriteLine($"Max String: {maxString}");

        // PrintEntityInfo 테스트
        PrintEntityInfo(new Entity { Id = 1, Name = "Sample Entity" });

        // Process 테스트
        DataProcessor processor = new DataProcessor();
        processor.Process("Hello, World!");
        processor.Process(new Person { Name = "Jane", Age = 22 });
    }

    public static T FindMax<T>(T a, T b) where T : IComparable<T>
    {
        if (a.CompareTo(b) > 0)
            return a;
        else
            return b;
    }

    public static void PrintEntityInfo<T>(T entity) where T : IEntity
    {
        Console.WriteLine($"ID: {entity.Id}, Name: {entity.Name}");
    }
}

public class DataConverter
{
    public T ConvertData<T>(object data)
    {
        return JsonSerializer.Deserialize<T>(data.ToString());
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public interface IEntity
{
    int Id { get; set; }
    string Name { get; set; }
}

public class Entity : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class DataProcessor
{
    public void Process<T>(T data) where T : class
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));

        Console.WriteLine($"Processing data of type: {data.GetType().Name}");
    }
}
