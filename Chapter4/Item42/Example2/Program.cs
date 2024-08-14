using System;
using System.Linq;
using System.Collections.Generic;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
}

public class Program
{
    private static bool isValidProduct(Product p) =>
        p.ProductName.LastIndexOf('C') == 0;

    public static void Main()
    {
        using (var dbContext = new ProductContext())
        {
            // AsEnumerable()로 변환하여 LINQ to Objects로 수행
            var q1 = from p in dbContext.Products.AsEnumerable()
                     where isValidProduct(p)
                     select p;

            // IQueryable<T>로 LINQ to SQL에서 수행, 그러나 isValidProduct는 변환 불가
            var q2 = from p in dbContext.Products
                     where isValidProduct(p)
                     select p;

            // 결과 출력: q1은 정상적으로 동작하지만, q2는 실행 시 예외 발생 가능
            Console.WriteLine("LINQ to Objects (AsEnumerable):");
            foreach (var product in q1)
            {
                Console.WriteLine(product.ProductName);
            }

            // Console.WriteLine("LINQ to SQL:");
            // foreach (var product in q2) // 이 코드는 예외를 발생시킬 수 있습니다.
            // {
            //     Console.WriteLine(product.ProductName);
            // }
        }
    }
}