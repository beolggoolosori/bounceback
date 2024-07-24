using System;

public interface IEntity { }

public class Customer : IEntity
{
    public string Name { get; set; } = "Default Customer";
}

public class Product : IEntity
{
    public string Name { get; set; } = "Default Product";
}

// 잘못된 접근 방식 (베이스 클래스나 인터페이스에 특화)
public class WrongRepository<T> where T : IEntity
{
    public void Add(T entity)
    {
        Console.WriteLine($"{typeof(T).Name} added to the database in WrongRepository.");
    }
}

public class CustomerWrongRepository : WrongRepository<Customer>
{
    public void AddCustomer(Customer customer)
    {
        Add(customer);
        Console.WriteLine("Additional customer-specific logic executed in CustomerWrongRepository.");
    }
}

public class ProductWrongRepository : WrongRepository<Product>
{
    public void AddProduct(Product product)
    {
        Add(product);
        Console.WriteLine("Additional product-specific logic executed in ProductWrongRepository.");
    }
}

// 올바른 접근 방식 (제네릭을 일반적으로 유지)
public class RightRepository<T> where T : IEntity
{
    public void Add(T entity)
    {
        Console.WriteLine($"{typeof(T).Name} added to the database in RightRepository.");
    }
}

public class CustomerService
{
    private readonly RightRepository<Customer> _repository;

    public CustomerService(RightRepository<Customer> repository)
    {
        _repository = repository;
    }

    public void AddCustomer(Customer customer)
    {
        _repository.Add(customer);
        Console.WriteLine("Additional customer-specific logic executed in CustomerService.");
    }
}

public class ProductService
{
    private readonly RightRepository<Product> _repository;

    public ProductService(RightRepository<Product> repository)
    {
        _repository = repository;
    }

    public void AddProduct(Product product)
    {
        _repository.Add(product);
        Console.WriteLine("Additional product-specific logic executed in ProductService.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // 잘못된 예
        Console.WriteLine("=== Wrong Approach ===");
        CustomerWrongRepository customerWrongRepo = new CustomerWrongRepository();
        customerWrongRepo.AddCustomer(new Customer());

        ProductWrongRepository productWrongRepo = new ProductWrongRepository();
        productWrongRepo.AddProduct(new Product());

        // 올바른 예
        Console.WriteLine("\n=== Right Approach ===");
        RightRepository<Customer> customerRightRepo = new RightRepository<Customer>();
        CustomerService customerService = new CustomerService(customerRightRepo);
        customerService.AddCustomer(new Customer());

        RightRepository<Product> productRightRepo = new RightRepository<Product>();
        ProductService productService = new ProductService(productRightRepo);
        productService.AddProduct(new Product());
    }
}
