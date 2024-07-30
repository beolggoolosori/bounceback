using System;
using System.Collections.Generic;
using System.Linq;

public class Customer
{
    public string Name { get; set; }
    public DateTime LastOrderDate { get; set; }
}

public static class CustomerExtensions
{
    public static void SendEmailCoupons(this IEnumerable<Customer> customers, string specialOffer)
    {
        foreach (var customer in customers)
        {
            Console.WriteLine($"Sending '{specialOffer}' coupon to {customer.Name}");
        }
    }

    public static IEnumerable<Customer> LostProspects(this IEnumerable<Customer> customers)
    {
        return from customer in customers
               where DateTime.Now - customer.LastOrderDate > TimeSpan.FromDays(30)
               select customer;
    }
}

// 사용 예제
public class Program
{
    public static void Main()
    {
        var customers = new List<Customer>
        {
            new Customer { Name = "John Doe", LastOrderDate = DateTime.Now.AddDays(-10) },
            new Customer { Name = "Jane Smith", LastOrderDate = DateTime.Now.AddDays(-40) },
            new Customer { Name = "Michael Johnson", LastOrderDate = DateTime.Now.AddDays(-35) }
        };

        var lostProspects = customers.LostProspects();
        lostProspects.SendEmailCoupons("Special 50% Off Offer");

        Console.WriteLine("Lost Prospects:");
        foreach (var customer in lostProspects)
        {
            Console.WriteLine(customer.Name);
        }
    }
}
