using System;

public class Employee
{
    public readonly int EmployeeID;
    public readonly DateTime RegistrationTime;
    public const string CompanyCode = "COMP123"; // 모든 직원에 대해 고정된 회사 코드

    public Employee(int id)
    {
        EmployeeID = id;
        RegistrationTime = DateTime.Now; // 현재 시각으로 초기화
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Employee ID: {EmployeeID}, Registered at: {RegistrationTime}, Company Code: {CompanyCode}");
    }
}

public class Program
{
    public static void Main()
    {
        Employee employee1 = new Employee(101);
        System.Threading.Thread.Sleep(2000); // 2초 대기
        Employee employee2 = new Employee(102);

        employee1.DisplayInfo();
        employee2.DisplayInfo();
    }
}