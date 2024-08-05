using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // Employee 리스트 생성
        var employees = new List<Employee>
        {
            new Employee("John", 50000),
            new Employee("Jane", 60000),
            new Employee("Doe", 55000)
        };

        // 총 급여 계산
        decimal totalSalary = Utils.Fold(employees, 0M, (sum, emp) => sum + emp.Salary);

        // 결과 출력
        Console.WriteLine($"Total Salary: {totalSalary}");

        // 숫자 리스트로 테스트
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        int sumOfNumbers = Utils.Fold(numbers, 0, (sum, num) => sum + num);

        // 결과 출력
        Console.WriteLine($"Sum of Numbers: {sumOfNumbers}");
    }
}

public static class Utils
{
    public static TResult Fold<T, TResult>(IEnumerable<T> sequence, TResult total, Func<TResult, T, TResult> accumulator)
    {
        foreach (var item in sequence)
        {
            total = accumulator(total, item);
        }
        return total;
    }
}

public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }

    public Employee(string name, decimal salary)
    {
        Name = name;
        Salary = salary;
    }
}
