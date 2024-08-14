using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
}

public class CustomerContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
}

public class Program
{
    public static void Main()
    {
        using (var dbContext = new CustomerContext())
        {
            // 첫 번째 예: IQueryable<T>를 사용하여 LINQ to SQL 쿼리 수행
            var q1 = from c in dbContext.Customers
                     where c.City == "London"
                     select c;

            var finalAnswer1 = from c in q1
                               orderby c.Name
                               select c;

            // 결과 출력
            Console.WriteLine("IQueryable<T> (LINQ to SQL) 결과:");
            foreach (var customer in finalAnswer1)
            {
                Console.WriteLine(customer.Name);
            }

            // 두 번째 예: AsEnumerable()로 변환하여 LINQ to Objects 수행
            var q2 = (from c in dbContext.Customers
                      where c.City == "London"
                      select c).AsEnumerable();

            var finalAnswer2 = from c in q2
                               orderby c.Name
                               select c;

            // 결과 출력
            Console.WriteLine("\nIEnumerable<T> (LINQ to Objects) 결과:");
            foreach (var customer in finalAnswer2)
            {
                Console.WriteLine(customer.Name);
            }
        }
    }
}
