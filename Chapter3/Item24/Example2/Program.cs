using System;

public interface IEntity
{
    string Name { get; set; }
}

public class Customer : IEntity
{
    public string Name { get; set; } = "Default Customer";
}

public class Product : IEntity
{
    public string Name { get; set; } = "Default Product";
}

// 기본 제네릭 클래스
public class GenericRepository<T> where T : IEntity
{
    public void Add(T entity)
    {
        Console.WriteLine($"{typeof(T).Name} {entity.Name} added to the generic database.");
    }
}

// 특정 타입에 대한 특화된 클래스
public class CustomerRepository : GenericRepository<Customer>
{
    public new void Add(Customer customer)
    {
        Console.WriteLine($"Customer {customer.Name} added to the customer database.");
        // Customer에 대한 추가 로직
    }
}

public class ProductRepository : GenericRepository<Product>
{
    public new void Add(Product product)
    {
        Console.WriteLine($"Product {product.Name} added to the product database.");
        // Product에 대한 추가 로직
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== General Generic Repository ===");
        GenericRepository<Customer> genericCustomerRepo = new GenericRepository<Customer>();
        genericCustomerRepo.Add(new Customer { Name = "John Doe" });

        GenericRepository<Product> genericProductRepo = new GenericRepository<Product>();
        genericProductRepo.Add(new Product { Name = "Laptop" });

        Console.WriteLine("\n=== Specialized Repositories ===");
        CustomerRepository customerRepo = new CustomerRepository();
        customerRepo.Add(new Customer { Name = "Jane Doe" });

        ProductRepository productRepo = new ProductRepository();
        productRepo.Add(new Product { Name = "Smartphone" });
    }
}
