using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int ProductCode { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public double Mrp { get; set; }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>()
        {
            new Product{ ProductCode=101, ProductName="Soap", Category="FMCG", Mrp=25 },
            new Product{ ProductCode=102, ProductName="Rice", Category="Grain", Mrp=50 },
            new Product{ ProductCode=103, ProductName="Oil", Category="FMCG", Mrp=120 },
            new Product{ ProductCode=104, ProductName="Wheat", Category="Grain", Mrp=40 },
            new Product{ ProductCode=105, ProductName="Shampoo", Category="FMCG", Mrp=30 }
        };

        Console.WriteLine("\n1. FMCG Products:");
        var fmcg = from p in products
                   where p.Category == "FMCG"
                   select p;
        foreach (var p in fmcg)
            Console.WriteLine($"{p.ProductCode} {p.ProductName} {p.Category} {p.Mrp}");



        Console.WriteLine("\n2. Grain Products:");
        var grain = products.Where(p => p.Category == "Grain");
        foreach (var p in grain)
            Console.WriteLine($"{p.ProductCode} {p.ProductName} {p.Category} {p.Mrp}");



        Console.WriteLine("\n3. Sort by Product Code:");
        var sortCode = from p in products
                       orderby p.ProductCode
                       select p;
        foreach (var p in sortCode)
            Console.WriteLine($"{p.ProductCode} {p.ProductName}");




        Console.WriteLine("\n4. Sort by Category:");
        var sortCategory = products.OrderBy(p => p.Category);
        foreach (var p in sortCategory)
            Console.WriteLine($"{p.ProductCode} {p.Category}");



        Console.WriteLine("\n5. Sort by MRP Ascending:");
        var sortMrpAsc = from p in products
                         orderby p.Mrp
                         select p;
        foreach (var p in sortMrpAsc)
            Console.WriteLine($"{p.ProductName} {p.Mrp}");



        Console.WriteLine("\n6. Sort by MRP Descending:");
        var sortMrpDesc = products.OrderByDescending(p => p.Mrp);
        foreach (var p in sortMrpDesc)
            Console.WriteLine($"{p.ProductName} {p.Mrp}");




        Console.WriteLine("\n7. Group by Category:");
        var groupCategory = from p in products
                            group p by p.Category;
        foreach (var group in groupCategory)
        {
            Console.WriteLine("Category: " + group.Key);
            foreach (var p in group)
                Console.WriteLine($"  {p.ProductName} {p.Mrp}");
        }




        Console.WriteLine("\n8. Group by MRP:");
        var groupMrp = products.GroupBy(p => p.Mrp);
        foreach (var group in groupMrp)
        {
            Console.WriteLine("MRP: " + group.Key);
            foreach (var p in group)
                Console.WriteLine($"  {p.ProductName}");
        }



        Console.WriteLine("\n9. Highest price in FMCG:");
        var maxFmcg = products
                        .Where(p => p.Category == "FMCG")
                        .OrderByDescending(p => p.Mrp)
                        .FirstOrDefault();
        Console.WriteLine($"{maxFmcg.ProductName} {maxFmcg.Mrp}");




        Console.WriteLine("\n10. Total Products Count:");
        int totalCount = (from p in products select p).Count();
        Console.WriteLine(totalCount);



        Console.WriteLine("\n11. FMCG Products Count:");
        int fmcgCount = products.Count(p => p.Category == "FMCG");
        Console.WriteLine(fmcgCount);



        Console.WriteLine("\n12. Max Price:");
        double maxPrice = products.Max(p => p.Mrp);
        Console.WriteLine(maxPrice);



        Console.WriteLine("\n13. Min Price:");
        double minPrice = (from p in products select p.Mrp).Min();
        Console.WriteLine(minPrice);



        Console.WriteLine("\n14. All products below 30:");
        bool allBelow30 = products.All(p => p.Mrp < 30);
        Console.WriteLine(allBelow30);




        Console.WriteLine("\n15. Any product below 30:");
        bool anyBelow30 = products.Any(p => p.Mrp < 30);
        Console.WriteLine(anyBelow30);

        Console.ReadLine();
    }
}