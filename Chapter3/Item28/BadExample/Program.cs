public class Customer
{
    public string Name { get; set; }
    public DateTime LastOrderDate { get; set; }
}

public class CustomerList : List<Customer>
{
    public void SendEmailCoupons(string specialOffer)
    {
        foreach (var customer in this)
        {
            Console.WriteLine($"Sending '{specialOffer}' coupon to {customer.Name}");
        }
    }

    public IEnumerable<Customer> LostProspects()
    {
        return from customer in this
               where DateTime.Now - customer.LastOrderDate > TimeSpan.FromDays(30)
               select customer;
    }
}

// 사용 예제
public class Program
{
    public static void Main()
    {
        var customers = new CustomerList
        {
            new Customer { Name = "John Doe", LastOrderDate = DateTime.Now.AddDays(-10) },
            new Customer { Name = "Jane Smith", LastOrderDate = DateTime.Now.AddDays(-40) },
            new Customer { Name = "Michael Johnson", LastOrderDate = DateTime.Now.AddDays(-35) }
        };

        var lostProspects = customers.LostProspects();
        customers.SendEmailCoupons("Special 50% Off Offer");

        Console.WriteLine("Lost Prospects:");
        foreach (var customer in lostProspects)
        {
            Console.WriteLine(customer.Name);
        }
    }
}
