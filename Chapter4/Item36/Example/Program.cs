using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
}

--쿼리 표현식
public class Program
{
    public static void Main()
    {
        var employees = new List<Employee>
        {
            new Employee { Name = "John", Age = 28, Salary = 50000, DepartmentId = 1 },
            new Employee { Name = "Jane", Age = 34, Salary = 60000, DepartmentId = 2 },
            new Employee { Name = "Doe", Age = 45, Salary = 70000, DepartmentId = 1 },
            new Employee { Name = "Smith", Age = 23, Salary = 40000, DepartmentId = 3 }
        };

        var departments = new List<Department>
        {
            new Department { Id = 1, Name = "HR" },
            new Department { Id = 2, Name = "IT" },
            new Department { Id = 3, Name = "Marketing" }
        };

        // 쿼리 표현식
        var query =
            from emp in employees
            join dept in departments on emp.DepartmentId equals dept.Id
            where emp.Age > 30
            orderby emp.Name
            group emp by dept.Name into empGroup
            select new
            {
                Department = empGroup.Key,
                Employees = empGroup
            };

        // 결과 출력
        Console.WriteLine("Using Query Expression:");
        foreach (var group in query)
        {
            Console.WriteLine($"Department: {group.Department}");
            foreach (var emp in group.Employees)
            {
                Console.WriteLine($"  Name: {emp.Name}, Age: {emp.Age}, Salary: {emp.Salary}");
            }
        }
    }
}

--메서드 호출 구문
public class Program
{
    public static void Main()
    {
        var employees = new List<Employee>
        {
            new Employee { Name = "John", Age = 28, Salary = 50000, DepartmentId = 1 },
            new Employee { Name = "Jane", Age = 34, Salary = 60000, DepartmentId = 2 },
            new Employee { Name = "Doe", Age = 45, Salary = 70000, DepartmentId = 1 },
            new Employee { Name = "Smith", Age = 23, Salary = 40000, DepartmentId = 3 }
        };

        var departments = new List<Department>
        {
            new Department { Id = 1, Name = "HR" },
            new Department { Id = 2, Name = "IT" },
            new Department { Id = 3, Name = "Marketing" }
        };

        // 메서드 호출 구문
        var methodQuery = employees
            .Join(departments, emp => emp.DepartmentId, dept => dept.Id, (emp, dept) => new { emp, dept })
            .Where(ed => ed.emp.Age > 30)
            .OrderBy(ed => ed.emp.Name)
            .GroupBy(ed => ed.dept.Name)
            .Select(g => new
            {
                Department = g.Key,
                Employees = g.Select(ed => ed.emp)
            });

        // 결과 출력
        Console.WriteLine("\nUsing Method Call Syntax:");
        foreach (var group in methodQuery)
        {
            Console.WriteLine($"Department: {group.Department}");
            foreach (var emp in group.Employees)
            {
                Console.WriteLine($"  Name: {emp.Name}, Age: {emp.Age}, Salary: {emp.Salary}");
            }
        }
    }
}
