using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
}


--즉시 평가

public class Program
{
    public static void Main()
    {
        var employees = new List<Employee>
        {
            new Employee { Name = "John", Age = 28, Salary = 50000 },
            new Employee { Name = "Jane", Age = 34, Salary = 60000 },
            new Employee { Name = "Doe", Age = 45, Salary = 70000 },
            new Employee { Name = "Smith", Age = 23, Salary = 40000 }
        };

        // 즉시 평가: ToList()를 사용하여 쿼리가 즉시 실행됩니다.
        var highSalaryEmployees = employees
            .Where(emp => emp.Salary > 50000)
            .ToList();

        // 데이터를 추가한 후
        employees.Add(new Employee { Name = "Alice", Age = 30, Salary = 80000 });

        // 즉시 평가된 결과를 출력 (새로운 데이터가 반영되지 않음)
        Console.WriteLine("Immediate Evaluation:");
        foreach (var emp in highSalaryEmployees)
        {
            Console.WriteLine($"Name: {emp.Name}, Salary: {emp.Salary}");
        }
    }
}


--지연 평가

public class Program
{
    public static void Main()
    {
        var employees = new List<Employee>
        {
            new Employee { Name = "John", Age = 28, Salary = 50000 },
            new Employee { Name = "Jane", Age = 34, Salary = 60000 },
            new Employee { Name = "Doe", Age = 45, Salary = 70000 },
            new Employee { Name = "Smith", Age = 23, Salary = 40000 }
        };

        // 지연 평가: IEnumerable<T>를 사용하여 쿼리가 즉시 실행되지 않습니다.
        var highSalaryEmployees = employees
            .Where(emp => emp.Salary > 50000);

        // 데이터를 추가한 후
        employees.Add(new Employee { Name = "Alice", Age = 30, Salary = 80000 });

        // 지연 평가된 결과를 출력 (새로운 데이터가 반영됨)
        Console.WriteLine("Deferred Evaluation:");
        foreach (var emp in highSalaryEmployees)
        {
            Console.WriteLine($"Name: {emp.Name}, Salary: {emp.Salary}");
        }
    }
}
