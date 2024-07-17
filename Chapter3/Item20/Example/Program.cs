using System;


// IComparable<T> 사용 예제
public class Employee : IComparable<Employee>
{
    public string Name { get; set; }
    public int Id { get; set; }

    public int CompareTo(Employee other)
    {
        if (other == null) return 1;
        return this.Id.CompareTo(other.Id);
    }
}

class Program
{
    static void Main()
    {
        Employee[] employees = {
            new Employee {Name = "John", Id = 2},
            new Employee {Name = "Jane", Id = 1},
            new Employee {Name = "Doe", Id = 3}
        };

        Array.Sort(employees);
        foreach (var emp in employees)
        {
            Console.WriteLine($"{emp.Name}, {emp.Id}");
        }
    }
}

using System;
using System.Collections.Generic;

public class Employee
{
    public string Name { get; set; }
    public int Id { get; set; }
}


// IComparer<T> 사용 예제
public class SortByName : IComparer<Employee>
{
    public int Compare(Employee x, Employee y)
    {
        return String.Compare(x.Name, y.Name);
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee> {
            new Employee {Name = "John", Id = 2},
            new Employee {Name = "Jane", Id = 1},
            new Employee {Name = "Doe", Id = 3}
        };

        employees.Sort(new SortByName());
        foreach (var emp in employees)
        {
            Console.WriteLine($"{emp.Name}, {emp.Id}");
        }
    }
}
